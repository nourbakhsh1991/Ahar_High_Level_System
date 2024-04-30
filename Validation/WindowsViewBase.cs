using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AharHighLevel.Validation
{
    public class WindowsViewBase : Window
    {
        ~WindowsViewBase()
        {
            OnUnload(this, null);
        }
        
        public virtual void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            ErrorContainer = (IValidationErrorContainer)DataContext;
            AddHandler(System.Windows.Controls.Validation.ErrorEvent, new RoutedEventHandler(Handler), true);
        }

        public virtual void OnUnload(object sender, System.Windows.RoutedEventArgs e)
        {
            RemoveHandler(System.Windows.Controls.Validation.ErrorEvent, new RoutedEventHandler(Handler));
        }

        internal IValidationErrorContainer ErrorContainer = null;

        // Based on exception handler from Josh Smith blog.
        public void Handler(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ValidationErrorEventArgs args = e as System.Windows.Controls.ValidationErrorEventArgs;

            if (args.Error.RuleInError is System.Windows.Controls.ValidationRule)
            {
                if (ErrorContainer != null)
                {
                    Tracer.LogValidation("ViewBase.Handler called for ValidationRule exception.");

                    // Only want to work with validation errors that are Exceptions because the business object has already recorded the business rule violations using IDataErrorInfo.
                    BindingExpression bindingExpression = args.Error.BindingInError as System.Windows.Data.BindingExpression;
                    Debug.Assert(bindingExpression != null);

                    string propertyName = bindingExpression.ParentBinding.Path.Path;
                    DependencyObject OriginalSource = args.OriginalSource as DependencyObject;

                    // Construct the error message.
                    string errorMessage = "";
                    ReadOnlyObservableCollection<System.Windows.Controls.ValidationError> errors = System.Windows.Controls.Validation.GetErrors(OriginalSource);
                    if (errors.Count > 0)
                    {
                        StringBuilder builder = new StringBuilder();
                        builder.Append(propertyName).Append(":");
                        System.Windows.Controls.ValidationError error = errors[errors.Count - 1];
                        {
                            if (error.Exception == null || error.Exception.InnerException == null)
                                builder.Append(error.ErrorContent.ToString());
                            else
                                builder.Append(error.Exception.InnerException.Message);
                        }
                        errorMessage = builder.ToString();
                    }

                    // Add or remove the validation error to the validation error collection.
                    Debug.Assert(args.Action == ValidationErrorEventAction.Added || args.Action == ValidationErrorEventAction.Removed);
                    StringBuilder errorID = new StringBuilder();
                    errorID.Append(args.Error.RuleInError.ToString());
                    if (args.Action == ValidationErrorEventAction.Added)
                    {
                        ErrorContainer.AddError(new ValidationError(propertyName, errorID.ToString(), errorMessage));
                    }
                    else if (args.Action == ValidationErrorEventAction.Removed)
                    {
                        ErrorContainer.RemoveError(propertyName, errorID.ToString());
                    }
                }
            }
        }
    }
}
