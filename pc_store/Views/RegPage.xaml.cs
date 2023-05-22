using pc_store.Models;
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
	public partial class RegPage : ContentPage
	{
		public RegPage ()
		{
			InitializeComponent ();
		}
        private void Button_Clicked(object sender, EventArgs e)
        {

            if (login.Text != null && password.Text != null)
            {
                var all_users = App.Database.GetUsers();
                bool flag = false;
                if (all_users != null)
                {
                    foreach (var item in all_users)
                    {
                        if (item.Login == login.Text) flag = true;
                    }
                    if (!flag)
                    {
                        var user = new Users()
                        {
                            Login = login.Text,
                            Pass = password.Text,
                            Role = "user"
                        };
                        App.Database.SaveUser(user);
                        DisplayAlert("Уведомление", "Успешно", "Ok");
                    }
                    else DisplayAlert("Уведомление", "Такой пользователь уже существует", "Ok");
                }
                else
                {
                    var user = new Users()
                    {
                        Login = login.Text,
                        Pass = password.Text,
                        Role = "user"
                    };
                    App.Database.SaveUser(user);
                    DisplayAlert("Уведомление", "Успешно", "Ok");

                }
            }
            else DisplayAlert("Уведомление", "Введите данные корректно", "Ok");


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StartPage());
        }
    }
}