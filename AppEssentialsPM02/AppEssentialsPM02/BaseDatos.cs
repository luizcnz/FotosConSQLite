using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppEssentialsPM02
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection db;
        public BaseDatos(String dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la bd
            db.CreateTableAsync<Picture>().Wait();
        }

        //Metodos del CRUD para Sitios

        #region Sitios
        //Select
        public Task<List<Picture>> ObtenerSitios()
        {
            return db.Table<Picture>().ToListAsync();
        }

        //Insert
        public Task<int> InsertPicture(Picture ubicacion)
        {
            if (ubicacion.id != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }
        //Traer un solo sitio (Ubicacion)
        public Task<Sitios> ObtenerSitios(int pid)
        {
            return db.Table<Sitios>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        //Delete
        public Task<int> EliminarFoto(Picture foto)
        {
            return db.DeleteAsync(foto);
        }
        #endregion Sitios
    }
}
