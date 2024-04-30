namespace Framework.ComponentModel
{
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

    /// <summary>
    /// Base class for members implementing <see cref="IDisposable"/>.
    /// </summary>
    public abstract class Disposable : IDisposable
    {
        private bool isDisposed;
        private Subject<Unit> whenDisposedSubject;

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class. Releases unmanaged
        /// resources and performs other cleanup operations before the <see cref="Disposable"/>
        /// is reclaimed by garbage collection. Will run only if the
        /// Dispose method does not get called.
        /// </summary>
        ~Disposable() => this.Dispose(false);

        /// <summary>
        /// Gets the when errors changed observable event. Occurs when the validation errors have changed for a property or for the entire object.
        /// </summary>
        /// <value>
        /// The when errors changed observable event.
        /// </value>
        public IObservable<Unit> WhenDisposed
        {
            get
            {
                if (this.IsDisposed)
                {
                    return Observable.Return(Unit.Default);
                }
                else
                {
                    if (this.whenDisposedSubject == null)
                    {
                        this.whenDisposedSubject = new Subject<Unit>();
                    }

                    return this.whenDisposedSubject.AsObservable();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Disposable"/> is disposed.
        /// </summary>
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        public bool IsDisposed => this.isDisposed;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Dispose all managed and unmanaged resources.
            this.Dispose(true);

            // Take this object off the finalization queue and prevent finalization code for this
            // object from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the managed resources implementing <see cref="IDisposable"/>.
        /// </summary>
        protected virtual void DisposeManaged()
        {
        }

        /// <summary>
        /// Disposes the unmanaged resources implementing <see cref="IDisposable"/>.
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {
        }

        /// <summary>
        /// Throws a <see cref="ObjectDisposedException"/> if this instance is disposed.
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources, called from the finalizer only.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.isDisposed)
            {
                // If disposing managed and unmanaged resources.
                if (disposing)
                {
                    this.DisposeManaged();
                }

                this.DisposeUnmanaged();

                this.isDisposed = true;

                if (this.whenDisposedSubject != null)
                {
                    // Raise the WhenDisposed event.
                    this.whenDisposedSubject.OnNext(Unit.Default);
                    this.whenDisposedSubject.OnCompleted();
                    this.whenDisposedSubject.Dispose();
                }
            }
        }
    }
}
namespace Framework.ComponentModel
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Reactive.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Notifies subscribers that a property in this instance is changing or has changed.
    /// </summary>
    public abstract class NotifyPropertyChanges : Disposable, INotifyPropertyChanged //, INotifyPropertyChanging
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { this.propertyChanged += value; }
            remove { this.propertyChanged -= value; }
        }

        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        // event PropertyChangingEventHandler INotifyPropertyChanging.PropertyChanging
        // {
        //     add { this.PropertyChanging += value; }
        //     remove { this.PropertyChanging -= value; }
        // }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        private event PropertyChangedEventHandler propertyChanged;

        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        // private event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Gets the when property changed observable event. Occurs when a property value changes.
        /// </summary>
        /// <value>
        /// The when property changed observable event.
        /// </value>
        public IObservable<string> WhenPropertyChanged
        {
            get
            {
                this.ThrowIfDisposed();

                return Observable
                    .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                        h => this.propertyChanged += h,
                        h => this.propertyChanged -= h)
                    .Select(x => x.EventArgs.PropertyName);
            }
        }

        /// <summary>
        /// Gets the when property changing observable event. Occurs when a property value is changing.
        /// </summary>
        /// <value>
        /// The when property changing observable event.
        /// </value>
        // public IObservable<EventPattern<PropertyChangingEventArgs>> WhenPropertyChanging
        // {
        //     get
        //     {
        //         return Observable
        //             .FromEventPattern<PropertyChangingEventHandler, PropertyChangingEventArgs>(
        //                 h => this.PropertyChanging += h,
        //                 h => this.PropertyChanging -= h)
        //             .AsObservable();
        //     }
        // }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.Assert(
                string.IsNullOrEmpty(propertyName) ||
                (this.GetType().GetRuntimeProperty(propertyName) != null),
                "Check that the property name exists for this instance.");

            PropertyChangedEventHandler eventHandler = this.propertyChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyNames">The property names.</param>
        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException(nameof(propertyNames));
            }

            foreach (string propertyName in propertyNames)
            {
                this.OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        /// Raises the PropertyChanging event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            Debug.Assert(
                string.IsNullOrEmpty(propertyName) ||
                (this.GetType().GetRuntimeProperty(propertyName) != null),
                "Check that the property name exists for this instance.");

            // PropertyChangingEventHandler eventHandler = this.PropertyChanging;

            // if (eventHandler != null)
            // {
            //     eventHandler(this, new PropertyChangingEventArgs(propertyName));
            // }
        }

        /// <summary>
        /// Raises the PropertyChanging event.
        /// </summary>
        /// <param name="propertyNames">The property names.</param>
        protected void OnPropertyChanging(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException(nameof(propertyNames));
            }

            foreach (string propertyName in propertyNames)
            {
                this.OnPropertyChanging(propertyName);
            }
        }

        /// <summary>
        /// Sets the value of the property to the specified value if it has changed.
        /// </summary>
        /// <typeparam name="TProp">The type of the property.</typeparam>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns><c>true</c> if the property was changed, otherwise <c>false</c>.</returns>
        protected bool SetProperty<TProp>(
            ref TProp currentValue,
            TProp newValue,
            [CallerMemberName] string propertyName = null)
        {
            this.ThrowIfDisposed();

            if (!object.Equals(currentValue, newValue))
            {
                this.OnPropertyChanging(propertyName);
                currentValue = newValue;
                this.OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the value of the property to the specified value if it has changed.
        /// </summary>
        /// <typeparam name="TProp">The type of the property.</typeparam>
        /// <param name="currentValue">The current value of the property.</param>
        /// <param name="newValue">The new value of the property.</param>
        /// <param name="propertyNames">The names of all properties changed.</param>
        /// <returns><c>true</c> if the property was changed, otherwise <c>false</c>.</returns>
        protected bool SetProperty<TProp>(
            ref TProp currentValue,
            TProp newValue,
            params string[] propertyNames)
        {
            this.ThrowIfDisposed();

            if (!object.Equals(currentValue, newValue))
            {
                this.OnPropertyChanging(propertyNames);
                currentValue = newValue;
                this.OnPropertyChanged(propertyNames);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the value of the property to the specified value if it has changed.
        /// </summary>
        /// <param name="equal">A function which returns <c>true</c> if the property value has changed, otherwise <c>false</c>.</param>
        /// <param name="action">The action where the property is set.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns><c>true</c> if the property was changed, otherwise <c>false</c>.</returns>
        protected bool SetProperty(
            Func<bool> equal,
            Action action,
            [CallerMemberName] string propertyName = null)
        {
            this.ThrowIfDisposed();

            if (equal())
            {
                return false;
            }

            this.OnPropertyChanging(propertyName);
            action();
            this.OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Sets the value of the property to the specified value if it has changed.
        /// </summary>
        /// <param name="equal">A function which returns <c>true</c> if the property value has changed, otherwise <c>false</c>.</param>
        /// <param name="action">The action where the property is set.</param>
        /// <param name="propertyNames">The property names.</param>
        /// <returns><c>true</c> if the property was changed, otherwise <c>false</c>.</returns>
        protected bool SetProperty(
            Func<bool> equal,
            Action action,
            params string[] propertyNames)
        {
            this.ThrowIfDisposed();

            if (equal())
            {
                return false;
            }

            this.OnPropertyChanging(propertyNames);
            action();
            this.OnPropertyChanged(propertyNames);

            return true;
        }
    }
}
namespace Framework.ComponentModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Framework.ComponentModel.Rules;

    /// <summary>
    /// Provides functionality to provide errors for the object if it is in an invalid state.
    /// </summary>
    /// <typeparam name="T">The type of this instance.</typeparam>
    public abstract class NotifyDataErrorInfo<T> : NotifyPropertyChanges, INotifyDataErrorInfo
        where T : NotifyDataErrorInfo<T>
    {
        private const string HasErrorsPropertyName = "HasErrors";

        private static RuleCollection<T> rules = new RuleCollection<T>();

        private Dictionary<string, List<object>> errors;

        /// <summary>
        /// Occurs when the validation errors have changed for a property or for the entire object. 
        /// </summary>
        event EventHandler<DataErrorsChangedEventArgs> INotifyDataErrorInfo.ErrorsChanged
        {
            add { this.errorsChanged += value; }
            remove { this.errorsChanged -= value; }
        }

        /// <summary>
        /// Occurs when the validation errors have changed for a property or for the entire object. 
        /// </summary>
        private event EventHandler<DataErrorsChangedEventArgs> errorsChanged;

        /// <summary>
        /// Gets the when errors changed observable event. Occurs when the validation errors have changed for a property or for the entire object. 
        /// </summary>
        /// <value>
        /// The when errors changed observable event.
        /// </value>
        public IObservable<string> WhenErrorsChanged
        {
            get
            {
                return Observable
                    .FromEventPattern<DataErrorsChangedEventArgs>(
                        h => this.errorsChanged += h,
                        h => this.errorsChanged -= h)
                    .Select(x => x.EventArgs.PropertyName);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the object has validation errors. 
        /// </summary>
        /// <value><c>true</c> if this instance has errors, otherwise <c>false</c>.</value>
        public virtual bool HasErrors
        {
            get
            {
                this.InitializeErrors();
                return this.errors.Count > 0;
            }
        }

        /// <summary>
        /// Gets the rules which provide the errors.
        /// </summary>
        /// <value>The rules this instance must satisfy.</value>
        protected static RuleCollection<T> Rules => rules;

        /// <summary>
        /// Gets the validation errors for the entire object.
        /// </summary>
        /// <returns>A collection of errors.</returns>
        public IEnumerable GetErrors() => this.GetErrors(null);

        /// <summary>
        /// Gets the validation errors for a specified property or for the entire object.
        /// </summary>
        /// <param name="propertyName">Name of the property to retrieve errors for. <c>null</c> to 
        /// retrieve all errors for this instance.</param>
        /// <returns>A collection of errors.</returns>
        public IEnumerable GetErrors(string propertyName)
        {
            Debug.Assert(
                string.IsNullOrEmpty(propertyName) ||
                (this.GetType().GetRuntimeProperty(propertyName) != null),
                "Check that the property name exists for this instance.");

            this.InitializeErrors();

            IEnumerable result;
            if (string.IsNullOrEmpty(propertyName))
            {
                List<object> allErrors = new List<object>();

                foreach (KeyValuePair<string, List<object>> keyValuePair in this.errors)
                {
                    allErrors.AddRange(keyValuePair.Value);
                }

                result = allErrors;
            }
            else
            {
                if (this.errors.ContainsKey(propertyName))
                {
                    result = this.errors[propertyName];
                }
                else
                {
                    result = new List<object>();
                }
            }

            return result;
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (string.IsNullOrEmpty(propertyName))
            {
                this.ApplyRules();
            }
            else
            {
                this.ApplyRules(propertyName);
            }

            base.OnPropertyChanged(HasErrorsPropertyName);
        }

        /// <summary>
        /// Called when the errors have changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            Debug.Assert(
                string.IsNullOrEmpty(propertyName) ||
                (this.GetType().GetRuntimeProperty(propertyName) != null),
                "Check that the property name exists for this instance.");

            EventHandler<DataErrorsChangedEventArgs> eventHandler = this.errorsChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Applies all rules to this instance.
        /// </summary>
        private void ApplyRules()
        {
            this.InitializeErrors();

            foreach (string propertyName in rules.Select(x => x.PropertyName))
            {
                this.ApplyRules(propertyName);
            }
        }

        /// <summary>
        /// Applies the rules to this instance for the specified property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void ApplyRules(string propertyName)
        {
            this.InitializeErrors();

            List<object> propertyErrors = rules.Apply((T)this, propertyName).ToList();

            if (propertyErrors.Count > 0)
            {
                if (this.errors.ContainsKey(propertyName))
                {
                    this.errors[propertyName].Clear();
                }
                else
                {
                    this.errors[propertyName] = new List<object>();
                }

                this.errors[propertyName].AddRange(propertyErrors);
                this.OnErrorsChanged(propertyName);
            }
            else if (this.errors.ContainsKey(propertyName))
            {
                this.errors.Remove(propertyName);
                this.OnErrorsChanged(propertyName);
            }
        }

        /// <summary>
        /// Initializes the errors and applies the rules if not initialized.
        /// </summary>
        private void InitializeErrors()
        {
            if (this.errors == null)
            {
                this.errors = new Dictionary<string, List<object>>();

                this.ApplyRules();
            }
        }
    }
}

namespace Framework.ComponentModel.Rules
{
    using System;

    /// <summary>
    /// A named rule containing an error to be used if the rule fails.
    /// </summary>
    /// <typeparam name="T">The type of the object the rule applies to.</typeparam>
    public abstract class Rule<T>
    {
        private string propertyName;
        private object error;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rule<T>"/> class.
        /// </summary>
        /// <param name="propertyName">The name of the property this instance applies to.</param>
        /// <param name="error">The error message if the rules fails.</param>
        protected Rule(string propertyName, object error)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            this.propertyName = propertyName;
            this.error = error;
        }

        /// <summary>
        /// Gets the name of the property this instance applies to.
        /// </summary>
        /// <value>The name of the property this instance applies to.</value>
        public string PropertyName => this.propertyName;

        /// <summary>
        /// Gets the error message if the rules fails.
        /// </summary>
        /// <value>The error message if the rules fails.</value>
        public object Error => this.error;

        /// <summary>
        /// Applies the rule to the specified object.
        /// </summary>
        /// <param name="obj">The object to apply the rule to.</param>
        /// <returns>
        /// <c>true</c> if the object satisfies the rule, otherwise <c>false</c>.
        /// </returns>
        public abstract bool Apply(T obj);
    }
}

namespace Framework.ComponentModel.Rules
{
    using System;

    /// <summary>
    /// Determines whether or not an object of type <typeparamref name="T"/> satisfies a rule and
    /// provides an error if it does not.
    /// </summary>
    /// <typeparam name="T">The type of the object the rule can be applied to.</typeparam>
    public sealed class DelegateRule<T> : Rule<T>
    {
        private Func<T, bool> rule;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateRule<T>"/> class.
        /// </summary>
        /// <param name="propertyName">>The name of the property the rules applies to.</param>
        /// <param name="error">The error if the rules fails.</param>
        /// <param name="rule">The rule to execute.</param>
        public DelegateRule(string propertyName, object error, Func<T, bool> rule)
            : base(propertyName, error)
        {
            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            this.rule = rule;
        }

        /// <summary>
        /// Applies the rule to the specified object.
        /// </summary>
        /// <param name="obj">The object to apply the rule to.</param>
        /// <returns>
        /// <c>true</c> if the object satisfies the rule, otherwise <c>false</c>.
        /// </returns>
        public override bool Apply(T obj) => this.rule(obj);
    }
}

namespace Framework.ComponentModel.Rules
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// A collection of rules.
    /// </summary>
    /// <typeparam name="T">The type of the object the rules can be applied to.</typeparam>
    public sealed class RuleCollection<T> : Collection<Rule<T>>
    {
        /// <summary>
        /// Adds a new <see cref="Rule{T}"/> to this instance.
        /// </summary>
        /// <param name="propertyName">The name of the property the rules applies to.</param>
        /// <param name="error">The error if the object does not satisfy the rule.</param>
        /// <param name="rule">The rule to execute.</param>
        public void Add(string propertyName, object error, Func<T, bool> rule) =>
            this.Add(new DelegateRule<T>(propertyName, error, rule));

        /// <summary>
        /// Applies the <see cref="Rule{T}"/>'s contained in this instance to <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to apply the rules to.</param>
        /// <param name="propertyName">Name of the property we want to apply rules for. <c>null</c>
        /// to apply all rules.</param>
        /// <returns>A collection of errors.</returns>
        public IEnumerable<object> Apply(T obj, string propertyName)
        {
            List<object> errors = new List<object>();

            foreach (Rule<T> rule in this)
            {
                if (string.IsNullOrEmpty(propertyName) || rule.PropertyName.Equals(propertyName))
                {
                    if (!rule.Apply(obj))
                    {
                        errors.Add(rule.Error);
                    }
                }
            }

            return errors;
        }
    }
}