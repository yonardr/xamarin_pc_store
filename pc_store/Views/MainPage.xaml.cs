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
            productsList.ItemsSource = App.Database.GetProducts();
            foreach (var type in App.Database.GetTypes())
            {
                picker_type.Items.Add($"{type.Name}");
            }

            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Book1 selectedBook = (Book1)e.SelectedItem;
            // Book1Page book1Page = new Book1Page();
            // book1Page.BindingContext = selectedBook;
            //await Navigation.PushModalAsync(book1Page);
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
    }
}