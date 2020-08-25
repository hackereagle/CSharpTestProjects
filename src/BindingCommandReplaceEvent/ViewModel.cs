using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Interactivity;

namespace BindingCommandReplaceEvent
{
    public class ViewModel
    {
        ObservableCollection<double> Items { get; set; }

        public ICommand DoSomethingCommand
        {
            get
            {
                Console.WriteLine("3");
                return _doSomethingCommand ??
                       (_doSomethingCommand = new DelegateCommand<double>(ExecuteDoSomethingWithItem));
                
            }
        }

        private DelegateCommand<double> _doSomethingCommand;

        private void ExecuteDoSomethingWithItem(double itemToDoSomethingWith)
        {
            Console.WriteLine("1");
            // Do something
        }

        public ViewModel()
        {
            Items = new ObservableCollection<double>();
            Console.WriteLine("2");
            // Fill the collection
        }
    }
    //public class ViewModel
    //{
    //    ObservableCollection<ItemViewModel> Items { get; set; }

    //    public ICommand DoSomethingCommand
    //    {
    //        get
    //        {
    //            return _doSomethingCommand ??
    //                   (_doSomethingCommand = new DelegateCommand<ItemViewModel>(ExecuteDoSomethingWithItem));
    //        }
    //    }

    //    private DelegateCommand<ItemViewModel> _doSomethingCommand;

    //    private void ExecuteDoSomethingWithItem(ItemViewModel itemToDoSomethingWith)
    //    {
    //        // Do something
    //    }

    //    public ViewModel()
    //    {
    //        Items = new ObservableCollection<ItemViewModel>();
    //        // Fill the collection
    //    }
    //}
}
