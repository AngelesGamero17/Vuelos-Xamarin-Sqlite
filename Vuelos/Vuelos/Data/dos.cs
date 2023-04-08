using System;
using System.Collections.Generic;
using System.Text;
using Vuelos.Models;
using SQLite;
using System.Threading.Tasks;
using System.Diagnostics;

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
            db.CreateTableAsync<Administrador>().Wait();
            db.CreateTableAsync<Reserva>().Wait();
        }
        /////////////////////////////////////////////CONTROLADOR DE REGISTRO DE USUARIO
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
            return db.Table<uno>().Where(a => a.Usuario == usuario && a.Contrasena == contrasena).FirstOrDefaultAsync().ContinueWith(task =>
            {
                var User = task.Result;
                if (User != null)
                {
                    SessionActiva.UserName = User.Usuario;
                    SessionActiva.UserId = User.IdVuelos;
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }

        ///////////////////////////////////////////////////CONTROLADOR-- REGISTRAR VUELO DE VIAJE
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
        //////////////////////////////////////CONTROLADOR DE REGISTRO DE ADMINSTRADOR
        public Task<int> SaveAdministradorAsync(Administrador Admin)
        {
            if (Admin.IdAdministrador != 0)
            {
                return db.UpdateAsync(Admin);
            }
            else
            {
                return db.InsertAsync(Admin);
            }
        }
        public Task<int> DeleteAdministradorAsync(Administrador Admin)
        {
            return db.DeleteAsync(Admin);
        }
        ///<sumary>
        ///Recuperar todos los registros de unos
        ///</sumary>
        ///<returns></returns>
        public Task<List<Administrador>> GetAdministradorAsync()
        {
            return db.Table<Administrador>().ToListAsync();
        }
        ///<sumary>
        ///Recuperar registros por el id
        ///</sumary>
        ///<param name="idAdministrador">Id de los registros que se requiere</param>
        ///<returns></returns>
        public Task<Administrador> GetAdministradorByIdAsync(int idAdministrador)
        {
            return db.Table<Administrador>().Where(a => a.IdAdministrador == idAdministrador).FirstOrDefaultAsync();
        }
        public Task<bool> VerifyAdministradorCredentialsAsync(string RolAdmin, string ContrasenaAdmin)
        {
            return db.Table<Administrador>().Where(a => a.RolAdmin == RolAdmin && a.ContrasenaAdmin == ContrasenaAdmin).CountAsync().ContinueWith(task =>
            {
                return task.Result > 0;
            });
        }

        /////////////////////////////////////////CONTROLADOR DE RESERVA
        public async Task<List<Reserva>> GetReservasByUserIdAsync(string userId)
        {
            return await db.Table<Reserva>()
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
        public async Task<bool> SaveReservaAsync(cuatro vuelo, string userId)
        {
            try
            {
                var reserva = new Reserva
                {
                    UserId = userId,
                    IdCompraVuelos = vuelo.IdCompraVuelos,
                };

                await db.InsertAsync(reserva);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al guardar la reserva: {ex.Message}");
                return false;
            }
        }
        public Task<cuatro> GetVueloById(int IdVuelo)
        {
            return db.Table<cuatro>().Where(a => a.IdCompraVuelos == IdVuelo).FirstOrDefaultAsync();
        }
        //////////////////////////////////////////Lista de la Compra de los Vuelos
        public async Task<List<ReservaViewModel>> GetReservacionByUserIdAsync()
        {
            var detalles = await db.QueryAsync<ReservaViewModel>(
        "SELECT r.UserId, r.IdCompraVuelos, u.Nombre,u.ApellidoPaterno,u.Dni, v.Precio, v.Estado, v.Imagen " +
        "FROM Reserva r " +
        "JOIN cuatro v ON r.IdCompraVuelos = v.IdCompraVuelos " +
        "JOIN uno u ON r.UserId = u.IdVuelos");

            return detalles;
        }
    }
}
