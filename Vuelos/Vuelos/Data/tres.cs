using System;
using System.Collections.Generic;
using System.Text;
using Vuelos.Models;
using SQLite;
using System.Threading.Tasks;

namespace Vuelos.Data
{
    public class tres
    {
        SQLiteAsyncConnection db;
        public tres(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<cuatro>().Wait();
        }
        public Task<int> SaveCuatroAsync(cuatro four)
        {
            if (four.IdCompraVuelos != 0)
            {
                return db.UpdateAsync(four);
            }
            else
            {
                return db.InsertAsync(four);
            }
        }
        public Task<int> DeleteCuatroAsync(cuatro four)
        {
            return db.DeleteAsync(four);
        }
        ///<sumary>
        ///Recuperar todos los registros de unos
        ///</sumary>
        ///<returns></returns>
        public Task<List<cuatro>> GetCuatroAsync()
        {
            return db.Table<cuatro>().ToListAsync();
        }
        ///<sumary>
        ///Recuperar registros por el id
        ///</sumary>
        ///<param name="idCompraVuelos">Id de los registros que se requiere</param>
        ///<returns></returns>
        public Task<cuatro> GetCuatroByIdAsync(int idCompraVuelos)
        {
            return db.Table<cuatro>().Where(a => a.IdCompraVuelos == idCompraVuelos).FirstOrDefaultAsync();
        }

    }
}