using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    // Repositorio que delegará las operaciones CRUD a la base de datos
    public class DBVehicleRepository : IVehicleRepository
    {
        // Inserta el vehículo en la fuente de datos relacional
        public void AddVehicle(Vehicle vehicle)
        {
            // TODO: abrir conexión, mapear propiedades de 'vehicle' a los campos de la tabla
            //       y ejecutar INSERT en la BD
            throw new NotImplementedException();
        }

        // Recupera un vehículo por su ID desde la base de datos
        public Vehicle Find(string id)
        {
            // TODO: abrir conexión, ejecutar SELECT WHERE ID = @id,
            //       mapear resultado a un objeto Vehicle y devolverlo
            throw new NotImplementedException();
        }

        // Obtiene todos los vehículos almacenados en la base de datos
        public ICollection<Vehicle> GetVehicles()
        {
            // TODO: abrir conexión, ejecutar SELECT * FROM Vehicles,
            //       mapear cada fila a un Vehicle y devolver la lista completa
            throw new NotImplementedException();
        }
    }
}
