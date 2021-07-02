using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace AppEssentialsPM02
{
    public partial class App : Application
    {
        static BaseDatos BD;
        public static string UbicacionDB = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FotoPage());
        }
        public static BaseDatos InstanciaBD
        {
            get
            {
                if (BD == null)
                {
                    BD = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "archivo.db3"));
                }
                return BD;
            }
        }

        public App(string DBlocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FotoPage());

            UbicacionDB = DBlocal;
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
