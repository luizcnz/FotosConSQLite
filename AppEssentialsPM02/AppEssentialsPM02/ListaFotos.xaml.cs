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
        private int ItemID;
        private string ItemRoute;
        private string ItemName;
        private string ItemDesc;

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

        private async void ListaFotosBD_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var almacenar = e.SelectedItem as pictures;

            ItemID = almacenar.id;
            ItemRoute = almacenar.ImageRoute;
            ItemName = almacenar.Name;
            ItemDesc = almacenar.Desc;

            seleccion.Text = Convert.ToString(ItemID);

            bool answer = await DisplayAlert("Mensaje", "Desea Visualizar esta imagen", "Si", "No");
            
            if(answer == true)
            {
                var Datos_VerFoto = new ParaVerFoto
                {
                    id_ver = ItemID,
                    ImageRoute_ver = ItemRoute,
                    Name_ver = ItemName,
                    Desc_ver = ItemDesc
                };

                var inf = new VerImagen(); inf.BindingContext = Datos_VerFoto; await Navigation.PushAsync(inf);
            }
            


        }

        private void btnborrar_Clicked(object sender, EventArgs e)
        {
            string x = Convert.ToString(ItemID);

            SQLiteConnection conexion = new SQLiteConnection(App.UbicacionDB);
            var borrarpersonas = conexion.Query<pictures>($"Delete FROM pictures WHERE id = '" + x + "' ");
            conexion.Close();

            if (ItemID != 0)
            {
                DisplayAlert("Aviso", "Se ha sido eliminado la foto numero " + ItemID + " de la lista de fotos", "Ok");

                OnAppearing();
            }
            else
            {
                DisplayAlert("Aviso", "No ha seleccionado ningun elemento para borrar!", "Ok");
            }



        }
    }
}