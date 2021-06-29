using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEssentialsPM02
{

    public class pictures
    {
        [AutoIncrement, PrimaryKey]
        public int id { set; get; }

        public string ImageRoute { get; set; }


        public string Name  { get; set; } // nombre de la foto (ahora uno tiene que ingresarlo)

        public string Desc  { get; set; } //descripcion de la foto (Tambien se tiene que ingresar)
    }
}
