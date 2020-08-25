using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestComboboxMvvm
{
    /// <summary>
    /// refer to https://www.c-sharpcorner.com/article/explain-combo-box-binding-in-mvvm-wpf/
    /// </summary>
    public class ViewModel
    {
        public ViewModel()
        {
            Persons = new System.Collections.ObjectModel.ObservableCollection<Person>()
            {
              new Person(){ Id=1, Name="Nirav"}
                    ,new Person(){Id=2,Name="Kapil"}
                    ,new Person(){Id=3 , Name="Arvind"}
                    ,new Person(){Id=4 , Name="Rajan"}
            };
        }

        private System.Collections.ObjectModel.ObservableCollection<Person> _persons;

        public System.Collections.ObjectModel.ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }
        private Person _sperson;

        public Person SPerson
        {
            get { return _sperson; }
            set { _sperson = value; }
        }
    }
}
