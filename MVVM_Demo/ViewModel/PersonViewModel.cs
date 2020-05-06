using MVVM_Demo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MVVM_Demo.ViewModel
{
    class PersonViewModel : DependencyObject
    {
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(PersonViewModel), new PropertyMetadata("", FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as PersonViewModel;
            if(current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterPerson;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(ICollectionView), typeof(PersonViewModel), new PropertyMetadata(null));



        public PersonViewModel()
        {
            Items = CollectionViewSource.GetDefaultView(Person.GetPeople());
            Items.Filter = FilterPerson;
        }

        private bool FilterPerson(object obj)
        {
            bool result = true;
            Person current = obj as Person;
            if (!string.IsNullOrEmpty(FilterText) && current != null && !current.FirstName.Contains(FilterText) && !current.LastName.Contains(FilterText))
            {
                result = false;
            }

            return result;
        }
    }
}
