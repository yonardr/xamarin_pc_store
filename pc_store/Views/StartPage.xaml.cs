using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pc_store.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
        public StartPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (login.Text == "123" && password.Text == "123") await Navigation.PushModalAsync(new Views.AdminPage());
                else
                {
                    var all_user = App.Database.GetUsers();
                    bool flag = true;
                    foreach (var item in all_user)
                    {
                        if (item.Login == login.Text && item.Pass == password.Text)
                        {
                            Application.Current.MainPage = new AppShell();
                            Jwt.id = item.Id;   
                            flag = false;
                        }
                    }
                    if (flag) DisplayAlert("Уведомление", "Такой пользователь не найден", "Ok");

                }
            }
            catch { DisplayAlert("Уведомление", "Ошибка", "Ok"); }


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegPage());
        }
    }
}