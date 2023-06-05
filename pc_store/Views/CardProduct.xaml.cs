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
	public partial class CardProduct : ContentPage
	{
        private string btn = "default";
		public CardProduct ()
		{
			InitializeComponent ();
            if(quantity.Text == "0")
            {
                btn = "none";
                btn_cart.Text = "Товара нет в наличии";
            }
            
        }
		
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (btn == "cart") btn_cart.Text = "Товар в корзине";
            if (btn == "default")
            {
                Cart cart = new Cart()
                {
                    prod_id = Convert.ToInt32(id.Text),
                    quantity = 1,
                    price = Convert.ToInt32(price.Text)
                };
                App.Database.SaveCart(cart, Jwt.id);

                btn = "cart";
                
            }  


        }
    }
}