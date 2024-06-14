using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmCommon
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);
        bool CanExecute(T parameter);
    }

    public class AsyncCommand<T> : IAsyncCommand<T>
    {
        public event EventHandler? CanExecuteChanged;

        private bool isExecuting;
        private readonly Func<T, Task> execute;
        private readonly Func<T, bool> canExecute;
        private readonly IErrorHandler errorHandler;

        public AsyncCommand(Func<T, Task> exec, Func<T, bool> canExec = null, IErrorHandler errHandler = null)
        {
            execute = exec;
            canExecute = canExec;
            errorHandler = errHandler;
        }

        public bool CanExecute(T parameter)
        {
            return !isExecuting && (canExecute?.Invoke(parameter) ?? true);
        }

        public async Task ExecuteAsync(T parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    isExecuting = true;
                    await execute(parameter);
                }
                finally
                {
                    isExecuting = false;
                }
            }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            ExecuteAsync((T)parameter).FireAndForgetSafeAsync(errorHandler);
        }
        #endregion
    }

    public static class TaskUtilities
    {
        //#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}
