//Modelo para exportar los datos de la foto tomada

using System;
using System.Collections.Generic;
using System.Text;

namespace AppEssentialsPM02
{
    public class ParaVerFoto
    {
        
        public int id_ver { set; get; } //Id de la foto

        public string ImageRoute_ver { get; set; } //ruta de la foto

        public string Name_ver { get; set; } // nombre de la foto (ahora uno tiene que ingresarlo)

        public string Desc_ver { get; set; } //descripcion de la foto (Tambien se tiene que ingresar)
    }
}
