using System;
using System.Collections.Generic;
using System.Text;
using Vuelos.Models;
using SQLite;
using System.Threading.Tasks;

namespace Vuelos.Data
{
    public class dos
    {
        SQLiteAsyncConnection db;
        public dos(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<uno>().Wait();
            db.CreateTableAsync<cuatro>().Wait();
        }
        public Task<int> SaveUnoAsync(uno one)
        {
            if (one.IdVuelos != 0)
            {
                return db.UpdateAsync(one);
            }
            else
            {
                return db.InsertAsync(one);
            }
        }

        public Task<int> DeleteUnoAsync(uno one)
        {
            return db.DeleteAsync(one);
        }
        ///<sumary>
        ///Recuperar todos los registros de unos
        ///</sumary>
        ///<returns></returns>
        public Task<List<uno>> GetUnoAsync()
        {
            return db.Table<uno>().ToListAsync();
        }
        ///<sumary>
        ///Recuperar registros por el id
        ///</sumary>
        ///<param name="idVuelos">Id de los registros que se requiere</param>
        ///<returns></returns>
        public Task<uno> GetUnoByIdAsync(int idVuelos)
        {
            return db.Table<uno>().Where(a => a.IdVuelos == idVuelos).FirstOrDefaultAsync();
        }
        public Task<bool> VerifyUnoCredentialsAsync(string usuario, string contrasena)
        {
            return db.Table<uno>().Where(a => a.Usuario == usuario && a.Contrasena == contrasena).CountAsync().ContinueWith(task =>
            {
                return task.Result > 0;
            });
        }

        ///////////////////////////////////////////////////
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
