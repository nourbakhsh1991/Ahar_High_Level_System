using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace AharHighLevel.Validation
{
    public class ValidationErrorEventTrigger : EventTriggerBase<DependencyObject>
    {
        protected override void OnAttached()
        {
            Behavior behavior = base.AssociatedObject as Behavior;
            FrameworkElement associatedElement = base.AssociatedObject as FrameworkElement;

            if (behavior != null)
            {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }
            if (associatedElement == null)
            {
                throw new ArgumentException("Validation Error Event trigger can only be associated to framework elements");
            }
            associatedElement.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new RoutedEventHandler(this.OnValidationError));
         
        }
        void OnValidationError(object sender, RoutedEventArgs args)
        {
            base.OnEvent(args);
        }
        protected override string GetEventName()
        {
            return System.Windows.Controls.Validation.ErrorEvent.Name;
        }
    }
}
