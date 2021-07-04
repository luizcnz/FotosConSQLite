using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace AppEssentialsPM02
{

    public class Picture
    {
        [AutoIncrement, PrimaryKey]
        public int id { set; get; }

        public string Name  { get; set; } // nombre de la foto (ahora uno tiene que ingresarlo)

        public string Desc  { get; set; } //descripcion de la foto (Tambien se tiene que ingresar)

        public byte [] Imagen { get; set; } 
    }
    //Esta clase solo se crea para convertir el byte a un stream y pueda ser leido por la bd
   
}
