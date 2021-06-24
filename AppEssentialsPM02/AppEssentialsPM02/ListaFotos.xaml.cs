using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using AppEssentialsPM02;
using System.Globalization;
using Plugin.Media.Abstractions;

namespace AppEssentialsPM02
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFotos : ContentPage
    {
        public class ImageFileToImageSourceConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var path = (string)value;
                return ImageSource.FromFile(path);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }



        public ListaFotos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            conexion.CreateTable<pictures>();
            var listafotos = conexion.Table<pictures>().ToList();
            ListaFotosBD.ItemsSource = listafotos;
            conexion.Close();



            //new MediaFile(file.Path, () => file.OpenStreamForReadAsync().Result, albumPath: null);

            //pictures pic = new pictures();

            /*carga.Text = pic.ImageRoute;*/

            //fotodb.Source = pic.ImageRoute;


        }

        private void ListaFotosBD_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}