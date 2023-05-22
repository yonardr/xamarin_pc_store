using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pc_store.Views.AdminPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddType : ContentPage
	{
		public AddType ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
			if(name.Text != null)
			{
				if(name.Text.Trim() != "")
				{
					var type = new Types()
					{
						Name = name.Text
					};
					App.Database.SaveType(type);
                    DisplayAlert("Уведомление", "Успешно", "Ok");
                }
                else DisplayAlert("Уведомление", "Заполните все поля", "Ok");
            }
            else DisplayAlert("Уведомление", "Заполните все поля", "Ok");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (type_name.Text != null)
            {
                if (type_name.Text.Trim() != "")
                {
                    var all_type = App.Database.GetTypes();
                    var id = all_type.Where(i => i.Name == type_name.Text).FirstOrDefault();
                    if(id != null)
                    {
                        App.Database.DeleteType(id.Id);
                        DisplayAlert("Уведомление", "Успешно", "Ok");
                    }
                    else DisplayAlert("Уведомление", "Такого типа нет", "Ok");

                }
                else DisplayAlert("Уведомление", "Заполните все поля", "Ok");
            }
            else DisplayAlert("Уведомление", "Заполните все поля", "Ok");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdminPage());
        }
    }
}