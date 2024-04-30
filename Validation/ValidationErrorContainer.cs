using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.Validation
{
    public delegate void ErrorsHaveChangedHandler(string propertyName);

    public interface IValidationErrorContainer
    {
        bool AddError(ValidationError error, bool isWarning = false);
        bool RemoveError(string propertyName, string errorID);

        int ErrorCount { get; }
        System.Collections.IEnumerable GetPropertyErrors(string propertyName);

        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }

    public class ValidationErrorContainer : IValidationErrorContainer
    {
        protected string lastPropertyValidated = null;

        public virtual bool AddError(ValidationError error, bool isWarning = false)
        {
            Debug.Assert(error != null);
            string propertyName = error.propertyName;

            Tracer.LogValidation(new StringBuilder("ValidationErrorContainer.AddError(")
                                 .Append(propertyName)
                                 .Append(", ID='")
                                 .Append(error.ID)
                                 .Append("', text='")
                                 .Append(error.ToString())
                                 .Append("') called.")
                                 .ToString());

            if (!errors.ContainsKey(propertyName))
                errors[propertyName] = new List<ValidationError>();

            lastPropertyValidated = propertyName;
            if (!errors[propertyName].Contains(error))
            {
                if (isWarning)
                    errors[propertyName].Add(error);
                else
                    errors[propertyName].Insert(0, error);

                NotifyErrorsChanged(propertyName);
                return true;
            }
            else
                return false;
        }

        public virtual bool RemoveError(string propertyName, string errorID)
        {
            Tracer.LogValidation(new StringBuilder("ValidationErrorContainer.RemoveError(")
                                .Append(propertyName)
                                .Append(", ID='")
                                .Append(errorID)
                                .Append(") called.")
                                .ToString());

            ValidationError error = new ValidationError(propertyName, errorID, "");
            if (!errors.ContainsKey(propertyName) || !errors[propertyName].Contains(error))
                return false;

            errors[propertyName].Remove(error);
            if (errors[propertyName].Count == 0)
            {
                errors.Remove(propertyName);
                if (errors.Count == 0)
                    lastPropertyValidated = null; // No errors. Good.
                else
                {
                    Dictionary<string, List<ValidationError>>.Enumerator p = errors.GetEnumerator();
                    p.MoveNext();
                    lastPropertyValidated = p.Current.Key;
                }
            }
            NotifyErrorsChanged(propertyName);
            return true;
        }

        public int ErrorCount
        {
            get { return errors.Count; }
        }

        protected void NotifyErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetPropertyErrors(string propertyName)
        {
            if (propertyName == "")
                return null;
            if (errors.Keys.Contains(propertyName))
                return errors[propertyName];
            else
                return null;
        }

        #region Debug
        // A debug method
        public string[] ValidationErrorMessages()
        {
            List<string> msgs = new List<string>();
            foreach (List<ValidationError> propertyErrors in errors.Values)
            {
                foreach (ValidationError error in propertyErrors)
                {
                    msgs.Add(error.ToString());
                }
            }
            return msgs.ToArray();
        }

        // A debug method.
        public string GetValidationErrorMessagesAsString()
        {
            StringBuilder builder = new StringBuilder();
            int cnt = 0;
            builder.Append("ValidationErrorContainer contents:(").Append(ErrorCount).Append(" errors)\n{\n");
            foreach (List<ValidationError> propertyErrors in errors.Values)
            {
                foreach (ValidationError error in propertyErrors)
                {
                    builder.Append(cnt.ToString())
                            .Append(". ")
                            .Append(error.Description)
                            .Append("\n");
                    cnt++;
                }
            }
            builder.Append("}");
            return builder.ToString();
        }
        #endregion

        protected Dictionary<string, List<ValidationError>> errors = new Dictionary<string, List<ValidationError>>();
    }
}
