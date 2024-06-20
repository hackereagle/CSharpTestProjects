using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCommon
{
    public class RelayCommand<T> : System.Windows.Input.ICommand
    {
        #region Fields
        /// <summary>
        /// Encapsulated the execute action
        /// </summary>
        Action<T>? execute;
        /// <summary>
        /// Encapsulated the representation for the validation of the excute method
        /// </summary>
        Predicate<T>? canExecute;

        #endregion Fields

        #region Constructors
        public RelayCommand(Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = DefaultCanExecute;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute != null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute != null? canExecute : canExecute;
        }
        #endregion Constructors

        #region ICommand Members
        public event EventHandler? CanExecuteChanged;
        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        System.Windows.Input.CommandManager.RequerySuggested += value;
        //        this.CanExecuteChangedInternal += value;
        //    }

        //    remove
        //    {
        //        System.Windows.Input.CommandManager.RequerySuggested -= value;
        //        this.CanExecuteChangedInternal -= value;
        //    }
        //}

        /// <summary>
        /// An event to allow the CanExecuteChanged event to be raised manually
        /// </summary>
        private event EventHandler CanExecuteChangedInternal;

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? canExecute(TranslateParameter(parameter)) : canExecute(TranslateParameter(parameter));
        }

        /// <summary>
        /// Execute the encapsulated command
        /// </summary>
        /// <param name="parameter">the parameter that represents the execution method</param>
        public void Execute(object parameter)
        {
            this.execute(TranslateParameter(parameter));
        }
        #endregion ICommand Members

        /// <summary>
        /// Raises the can execure changed
        /// </summary>
        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// destroys his instance
        /// </summary>
        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }

        /// <summary>
        /// Defines if command can be executed (default behaviour).
        /// In order to match canExecute which is function pointer returning boolean value.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>Always true</returns>
        private bool DefaultCanExecute(T parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines if command can't be executed (default behaviour).
        /// In order to match canExecute which is function pointer returning boolean value.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>Always false</returns>
        //private bool CantExecute(T parameter)
        //{
        //    return false;
        //}

        private T TranslateParameter(object parameter)
        {
            T value = default(T);
            if (parameter != null && typeof(T).IsEnum)
                value = (T)Enum.Parse(typeof(T), (string)parameter);
            else
                value = (T)parameter;
            return value;
        }

    }
}
