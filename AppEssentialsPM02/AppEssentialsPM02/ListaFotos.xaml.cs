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
using System.Collections.ObjectModel;
using System.IO;

namespace AppEssentialsPM02
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFotos : ContentPage
    {
        private int ItemID;
        private string ItemRoute;
        private string ItemName;
        private string ItemDesc;




        public ListaFotos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            var listafotos = await App.InstanciaBD.ObtenerSitios();
            //Creamos un colleccion observable para que los cambios que se realizan en el modelo se reflejen de maner automatica
            //en la vista
            ObservableCollection<Picture> observableCollectionFotos = new ObservableCollection<Picture>();
            ListaFotosBD.ItemsSource = observableCollectionFotos;
            foreach(Picture imagen in listafotos)
            {
                observableCollectionFotos.Add(imagen);      
            }





        }

        private async void ListaFotosBD_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*
            var almacenar = e.SelectedItem as Picture;

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
           */ 


        }

        private async void MtmEliminarFoto_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var PictureSelected = menuItem.CommandParameter as Picture;
            //Se pregunta al usuario si desea elminar la ubicación
            bool confirmacion = await DisplayAlert("¿Desea borrar la ubicación?", "Los datos de borrarán de forma permanente", "Aceptar", "Cancelar ");
            if (confirmacion)
            {
                await App.InstanciaBD.EliminarFoto(PictureSelected);
            }
        }

        private void btnborrar_Clicked(object sender, EventArgs e)
        {

        }

        private async void ListaFotosBD_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var PictureSelected = e.Item as Picture;
            var verImagen = new VerImagen(); 
              verImagen.BindingContext = PictureSelected; 
             await Navigation.PushAsync(verImagen);
         }
    }
}