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
		public CardProduct ()
		{
			InitializeComponent ();

			//var all_types = App.Database.GetTypes();
			//foreach (var item in all_types)
			//{
			//	if(Convert.ToInt32(type.Text) == item.Id) type.Text = "fsdafdsa";
            //}
            
        }
		
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}