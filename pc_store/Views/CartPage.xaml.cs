using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        }
        protected override void OnAppearing()
        {
           
            var list = new List<ViewCart>();
            //var y = App.Database.Getttt();
            var a = App.Database.GetCartsUser(Jwt.id);
            foreach (var item in a)
            {
                if (item != null)
                {
                    var prod_name = App.Database.GetProduct(item.prod_id).name;
                    var l = new ViewCart()
                    {
                        Id = item.Id,
                        prod_id = item.prod_id,
                        name = prod_name,
                        price = item.price,
                        quantity = item.quantity,
                    };
                    list.Add(l);
                }
            }
            productsList.ItemsSource = list;

            double price = 0;
            foreach (var item in a)
            {
                if (item != null) price += item.price * item.quantity;
            }
            last_price.Text = "Итого: " + Convert.ToString(price);

            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewCart selected = (ViewCart)e.SelectedItem;
			string answer = await DisplayActionSheet("", "Cancel", null, "Удалить", "Указать кол-во");
			if (answer == "Удалить")
			{
				App.Database.DeleteCart(selected.Id, Jwt.id);
                OnAppearing();
            }
            if(answer == "Указать кол-во")
            {
                var q_prod = App.Database.GetProduct(selected.prod_id);
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
                        OnAppearing();
                    }
                    else await DisplayAlert("Такого кол-во товара нет в наличии", "", "ок");
                }
            }
        }

    
        class ViewCart : Cart
        {
            public string name { get; set; }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            double price = 0;
            List<int> arr_id_carts = new List<int>();
            var a = App.Database.GetCartsUser(Jwt.id);
            foreach (var item in a)
            {
                if(item != null) arr_id_carts.Add(item.Id);
                if (item != null) price += item.price * item.quantity;
            }
            var res = App.Database.CreateOrder(arr_id_carts, Jwt.id, price);
            await DisplayAlert($"Заказ #{res} создан", "", "ок") ;
        }
    }
}