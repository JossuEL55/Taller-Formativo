using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    // Define las operaciones CRUD básicas para un repositorio de vehículos
    public interface IVehicleRepository
    {
        // Obtiene todos los vehículos almacenados
        ICollection<Vehicle> GetVehicles();

        // Agrega un nuevo vehículo al repositorio
        void AddVehicle(Vehicle vehicle);

        // Busca un vehículo por su identificador único (ID)
        Vehicle Find(string id);
    }
}
