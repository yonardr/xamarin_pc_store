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
    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ordersList.ItemsSource = App.Database.GerOrders(Jwt.id);
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Orders selected = (Orders)e.SelectedItem;

            string res = "";
            var carts = App.Database.GerDataOrder(selected.Id);
            foreach (var cart in carts)
            {
                if (cart != null)
                {
                    res += App.Database.GetProduct(cart.prod_id).name + "\n";
                    res += "Кол-во: " + cart.quantity + "\n";
                    res += "Цена за 1шт: " + cart.price + "\n";
                    res += "Общая цена: " + cart.price* cart.quantity + "\n\n";
                }
            }
            await DisplayAlert("Информация о заказе", $"{res} \nИтоговая цена: {selected.price}", "ok");

        }
    }
}