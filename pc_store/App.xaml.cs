using pc_store.Services;
using pc_store.Views;
using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace pc_store
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "pc_store.db";
        public static Repository database;
        public static Repository Database
        {
            get
            {
                if (database == null)
                {
                    database = new Repository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
