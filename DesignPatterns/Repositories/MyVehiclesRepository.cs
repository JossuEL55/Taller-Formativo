using DesignPatterns.Models;           
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    // Repositorio en memoria que implementa IVehicleRepository
    public class MyVehiclesRepository : IVehicleRepository
    {
        // Almacén singleton de vehículos en memoria
        private readonly MemoryCollection _memoryCollection = MemoryCollection.Instance;

        // Constructor vacío (el contenedor de DI lo instanciará)
        public MyVehiclesRepository()
        {
        }

        // Agrega un vehículo a la colección en memoria
        public void AddVehicle(Vehicle vehicle)
        {
            _memoryCollection.Vehicles.Add(vehicle);
        }

        // Busca un vehículo por su ID (guid) en la colección
        public Vehicle Find(string id)
        {
            // Convierte el string a Guid y compara con la propiedad ID de cada vehículo
            return _memoryCollection.Vehicles
                .FirstOrDefault(v => v.ID.Equals(new Guid(id)));
        }

        // Devuelve todos los vehículos almacenados en memoria
        public ICollection<Vehicle> GetVehicles()
        {
            return _memoryCollection.Vehicles;
        }
    }
}
