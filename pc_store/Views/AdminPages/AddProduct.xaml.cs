using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace pc_store.Views.AdminPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProduct : ContentPage
	{
		public AddProduct ()
		{
			InitializeComponent ();
            foreach (var type in App.Database.GetTypes())
            {
                picker_type.Items.Add($"{type.Name}");
            }
            foreach (var p in App.Database.GetProducts())
            {
                picker_prod.Items.Add($"{p.name}");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			if(name.Text != null && price.Text != null && description.Text != null && img.Text != null && picker_type.SelectedIndex != -1)
			{
				if (name.Text.Trim() != "" && price.Text.Trim() != "" && description.Text.Trim() != "" && img.Text.Trim() != "")
                {
					var type_id = App.Database.GetTypes().Where(i=> i.Name == picker_type.Items[picker_type.SelectedIndex]).FirstOrDefault();
					var product = new Products()
					{
						name = name.Text,
						price = Convert.ToInt32(price.Text),
						description = description.Text,
						img = img.Text,
						type = type_id.Id,
						quantity = Convert.ToInt32(quantity.Text),
                    };
					App.Database.SaveProduct (product);
                    DisplayAlert("Уведомление", "Успешно", "Ok");
                }
				else DisplayAlert("Уведомление", "Заполните все поля", "Ok");
			}
            else DisplayAlert("Уведомление", "Заполните все поля", "Ok");

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdminPage());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            try { 
            var prod_name = picker_prod.Items[picker_prod.SelectedIndex];
            var prod = App.Database.GetProducts().Where(i => i.name == prod_name).FirstOrDefault();
            App.Database.DeleteProduct(prod.Id);
            DisplayAlert("Удалено", "", "Ok");
            }
            catch(Exception ex)
            {
                DisplayAlert("Ошибка", $"{ex}", "Ok");
            }

        }
    }
}