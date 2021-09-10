using Acr.UserDialogs;
using HomeCare.Models;
using HomeCare.Services.Users;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewDevice : ContentPage, INotifyPropertyChanged
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private UserHandler userHandler;
        private ObservableCollection<Devices> _listOfItems;
        public ObservableCollection<Devices> ListOfItems
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
        public void OnEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Devices iUser = ListOfItems.Where(x => x.Name == mi.CommandParameter.ToString()).FirstOrDefault();
            Devices Tmp = new Devices() { Name = iUser.Name, Phone = iUser.Phone };
            bool cnsl = false;
            UserDialogs.Instance.ActionSheet(new ActionSheetConfig()
                           .SetTitle("Edit")
                           .Add("Name", async () =>
                           {
                               var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                               {
                                   Title = $"Editing {iUser.Name}",
                                   Text = iUser.Name,
                                   IsCancellable = true
                               });
                               if (result.Ok)
                               {
                                   cnsl = true;
                                   Tmp.Name = result.Text;
                                   ListOfItems.Remove(iUser);
                                   ListOfItems.Add(Tmp);
                               }
                           })
                           .Add("Phone", async () =>
                           {
                               var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
                               {
                                   Title = $"Editing {iUser.Phone}",
                                   Text = iUser.Phone,
                                   IsCancellable = true
                               });
                               if (result.Ok)
                               {
                                   cnsl = true;
                                   Tmp.Phone = result.Text;
                                   ListOfItems.Remove(iUser);
                                   ListOfItems.Add(Tmp);
                               }
                           })
                           .SetCancel()
                       );

            if (cnsl)
            {
                UserDialogs.Instance.Toast(new ToastConfig($"{iUser.Name} Changed.")
                                     .SetDuration(TimeSpan.FromSeconds(5))
                                     .SetPosition(ToastPosition.Bottom)
                                     .SetAction(x => x
                                         .SetText("Undo")
                                         .SetAction(() =>
                                         {
                                             ListOfItems.Remove(Tmp);
                                             ListOfItems.Add(iUser);
                                         })
                                     )
                                 );
                ListOfItems = ListOfItems;
            }
        }
        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Devices iUser = ListOfItems.Where(x => x.Name == mi.CommandParameter.ToString()).FirstOrDefault();
            await DisplayAlert("Delete", iUser.Name, "OK");
            bool answer = await DisplayAlert("Delete item", $"Would you like to remove {iUser.Name} permanently?", "Yes", "No");
            if (answer)
            {
                ListOfItems.Remove(iUser);
                //ListOfItems = new ObservableCollection<User>(ListOfItems.Where(x => x.Name != iName).ToList());

                UserDialogs.Instance.Toast(new ToastConfig($"{iUser.Name} Deleted.")
                    .SetDuration(TimeSpan.FromSeconds(5))
                    .SetPosition(ToastPosition.Bottom)
                    .SetAction(x => x
                        .SetText("Undo")
                        .SetAction(() => ListOfItems.Add(iUser))
                    )
                );
                ListOfItems = ListOfItems;
            }
        }
        public AddNewDevice()
        {
            InitializeComponent();
            this.BindingContext = this;
            userHandler = new UserHandler();
            ListOfItems = new ObservableCollection<Devices>(userHandler.GetAllUsers());
            lstDevices.ItemsSource = ListOfItems;
        }
         
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddDevice());
        }
    }
}