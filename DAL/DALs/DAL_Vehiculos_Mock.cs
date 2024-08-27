using DAL.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALs
{
    public class DAL_Vehiculos_Mock : IDAL_Vehiculos
    {
        public void AddVehiculo(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehiculo(long id)
        {
            throw new NotImplementedException();
        }

        public List<Vehiculo> GetVehiculos()
        {
            throw new NotImplementedException();
        }

        public Vehiculo GetVehiculo(long id)
        {
            throw new NotImplementedException();
        }

        public List<Vehiculo> GetVehiculosByPersona(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }
    }
}
