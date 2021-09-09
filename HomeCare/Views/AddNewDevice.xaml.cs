using HomeCare.Services.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewDevice : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<User> _listOfItems;
        public ObservableCollection<User> ListOfItems
        {
            get
            {
                return _listOfItems;
            }
            set
            {
                if (_listOfItems != value)
                {
                    _listOfItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public AddNewDevice()
        {
            InitializeComponent();

            ListOfItems = new ObservableCollection<User>(UserHandler.GetAllUsers());

            this.listView.BindingContext = ListOfItems;

            var moreAction = new MenuItem { Text = "Edit" };
            moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            moreAction.Clicked += (sender, e) => {
                var mi = ((MenuItem)sender); 
            };

            var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
            deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            deleteAction.Clicked += (sender, e) => {
                var mi = ((MenuItem)sender);
             };

            //
            // add context actions to the cell
            //
            //ContextActions.Add(moreAction);
            //ContextActions.Add(deleteAction);


        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
            DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender); 
            //DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
            ListOfItems.Remove(ListOfItems.Where(x => x.phone == mi.CommandParameter.ToString()).FirstOrDefault());
        }  
    }
}