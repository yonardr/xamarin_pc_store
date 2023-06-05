using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pc_store.Views.AdminPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddStockProd : ContentPage
	{
		public AddStockProd ()
		{
			InitializeComponent ();
            var products = App.Database.GetProducts();
            foreach (var product in products) { picker_products.Items.Add(product.name); }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var name_prod = picker_products.Items[picker_products.SelectedIndex];
            var prod = App.Database.GetProducts().Where(i=> i.name == name_prod).FirstOrDefault();
            Products new_prod = new Products() { 
                Id=prod.Id ,name = prod.name, price = prod.price, description = prod.description, img = prod.img, type = prod.type, quantity = Convert.ToInt32(quantity.Text)
            };
            App.Database.SaveProduct(new_prod);
            DisplayAlert("Успешно", "", "ok");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdminPage());
        }


    }
}