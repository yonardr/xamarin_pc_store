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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            picker_type.Items.Clear();
            productsList.ItemsSource = App.Database.GetProducts();

            picker_type.Items.Add($"Все");
            foreach (var type in App.Database.GetTypes())
            {
                picker_type.Items.Add($"{type.Name}");
            }
            picker_type.SelectedIndex = 0;
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Products selectedProd = (Products)e.SelectedItem;
            CardProduct Page = new CardProduct();
            Page.BindingContext = selectedProd;
            await Navigation.PushModalAsync(Page);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            //Book1 book = new Book1();
            // Book1Page book1Page = new Book1Page();
            // book1Page.BindingContext = book;
            // await Navigation.PushModalAsync(book1Page);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StartPage());
        }

        private void picker_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Prods = App.Database.GetProducts();
            List<Products> arrProd = new List<Products>();
            if (picker_type.SelectedIndex <= 0)
            {
                productsList.ItemsSource = App.Database.GetProducts();
            }
            else
            {
                var type_name = picker_type.Items[picker_type.SelectedIndex];
                var getType = App.Database.GetTypes().Where(i => i.Name == type_name).FirstOrDefault();
                foreach (var item in Prods)
                {
                    if (item.type == getType.Id)
                    {

                        arrProd.Add(item);
                    }

                }
                productsList.ItemsSource = arrProd;
            }
            
        }
    }
}