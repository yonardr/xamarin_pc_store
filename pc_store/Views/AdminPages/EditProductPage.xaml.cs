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
	public partial class EditProductPage : ContentPage
	{
		public EditProductPage ()
		{
			InitializeComponent ();
		}

        private void btn_Clicked(object sender, EventArgs e)
        {
			Products p = new Products() {
				Id = Convert.ToInt32(id.Text),
				name = name.Text,
                img = img.Text,
                type = Convert.ToInt32(type.Text),
                description = description.Text,	
				price = Convert.ToInt32(price.Text)
            };
			App.Database.SaveProduct(p);
			DisplayAlert("Сохранено", "", "Ок");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EditProduct()); 
        }

        private async void btn_delete2_Clicked(object sender, EventArgs e)
        {
            App.Database.DeleteProduct(Convert.ToInt32(id.Text));
            DisplayAlert("Удалено", "", "Ок");
            await Navigation.PushModalAsync(new EditProduct());
        }
    }
}