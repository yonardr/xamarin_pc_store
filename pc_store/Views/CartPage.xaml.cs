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
	public partial class CartPage : ContentPage
	{
		public CartPage ()
		{
			InitializeComponent ();
            var a = App.Database.GetCartsUser(Jwt.id);
			productsList.ItemsSource = a;
        }

     
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cart selected = (Cart)e.SelectedItem;
			string answer = await DisplayActionSheet("", "Cancel", null, "Удалить", "Указать кол-во");
			if (answer == "Удалить")
			{
				App.Database.DeleteCart(selected.Id, Jwt.id);
                var a = App.Database.GetCartsUser(Jwt.id);
                productsList.ItemsSource = a;
            }
            if(answer == "Указать кол-во")
            {
                var q_prod = App.Database.GetProduct(selected.Id);
                string result = await DisplayPromptAsync("Укажите кол-во товара", "");
                if (result != null)
                {
                    if (Convert.ToInt32(result) <= q_prod.quantity)
                    {
                        Cart c = new Cart()
                        {
                            Id = selected.Id,
                            price = selected.price,
                            prod_id = selected.prod_id,
                            quantity = Convert.ToInt32(result)
                        };
                        App.Database.SaveCart(c, Jwt.id);
                    }
                    else await DisplayAlert("Такого кол-во товара нет в наличии", "", "ок");
                }
            }
        }
    }
}