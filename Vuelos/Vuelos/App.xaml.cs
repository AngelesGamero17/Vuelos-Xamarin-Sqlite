using System;
using Vuelos.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace Vuelos
{
    public partial class App : Application
    {
        static dos db;
        public App()
        {
            InitializeComponent();
            MainPage=new NavigationPage(new login());
            //MainPage = new MainPage();
        }
        public static dos SQLiteDB
        { 
            get
            {
                if (db==null)
                {
                    db=new dos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Vuelos.db3"));
                }
                return db;
            }
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
