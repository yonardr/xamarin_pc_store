using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pc_store.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfPage : ContentPage
    {
        public ConfPage()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            
            var type_id = App.Database.GetTypes().Where(i => i.Name == "Видеокарта").FirstOrDefault().Id;
            var video = App.Database.GetProducts().Where(i => i.type == type_id);
            foreach (var item in video)
            {
                picker_video.Items.Add(item.name);
            }

            type_id = App.Database.GetTypes().Where(i => i.Name == "SSD").FirstOrDefault().Id;
            var ssd = App.Database.GetProducts().Where(i => i.type == type_id);
            foreach (var item in ssd)
            {
                picker_ssd.Items.Add(item.name);
            }

            type_id = App.Database.GetTypes().Where(i => i.Name == "Охлаждение").FirstOrDefault().Id;
            var cool = App.Database.GetProducts().Where(i => i.type == type_id);
            foreach (var item in cool)
            {
                picker_cool.Items.Add(item.name);
            }

            type_id = App.Database.GetTypes().Where(i => i.Name == "ОЗУ").FirstOrDefault().Id;
            var ozu = App.Database.GetProducts().Where(i => i.type == type_id);
            foreach (var item in ozu)
            {
                picker_ozu.Items.Add(item.name);
            }

            //type_id = App.Database.GetTypes().Where(i => i.Name == "Процессор").FirstOrDefault().Id;
            //var process = App.Database.GetProducts().Where(i => i.type == type_id);
            //foreach (var item in process)
            //{
            //    picker_video.Items.Add(item.name);
            //}

            base.OnAppearing();
        }
    }
}