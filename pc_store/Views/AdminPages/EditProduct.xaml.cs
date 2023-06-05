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
	public partial class EditProduct : ContentPage
	{
		public EditProduct ()
		{
			InitializeComponent ();
            productsList.ItemsSource = App.Database.GetProducts();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Products selectedProd = (Products)e.SelectedItem;
            EditProductPage Page = new EditProductPage();
            Page.BindingContext = selectedProd;
            await Navigation.PushModalAsync(Page);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AdminPage());
        }
    }
}