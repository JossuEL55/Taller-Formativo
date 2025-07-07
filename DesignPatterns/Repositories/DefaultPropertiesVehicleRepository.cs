using System;
using System.Collections.Generic;
using DesignPatterns.Models;

namespace DesignPatterns.Repositories
{
    // Decorator para IVehicleRepository que inyecta año y 20 propiedades por defecto
    // antes de delegar al repositorio real.
    public class DefaultPropertiesVehicleRepository : IVehicleRepository
    {
        private readonly IVehicleRepository _inner;
        private readonly IDictionary<string, object> _defaults;

        public DefaultPropertiesVehicleRepository(IVehicleRepository inner)
        {
            _inner = inner;

            // Definición de las 20 propiedades por defecto
            _defaults = new Dictionary<string, object>
            {
                ["ColorSecundario"] = "Negro",
                ["Transmision"] = "Manual",
                ["Puertas"] = 4,
                ["TieneAireAcondicionado"] = true,
                ["TipoCombustible"] = "Gasolina",
                ["Asientos"] = 5,
                ["NumeroChasis"] = string.Empty,
                ["PesoKg"] = 1500.0,      // en kilogramos
                ["LargoM"] = 4.50,        // en metros
                ["AnchoM"] = 1.80,        // en metros
                ["AlturaM"] = 1.40,        // en metros
                ["CilindradaLitros"] = 2.0,         // en litros
                ["EsElectrico"] = false,
                ["Traccion"] = "Trasera",
                ["AirbagsDelanteros"] = 2,
                ["AirbagsLaterales"] = 2,
                ["TieneSunroof"] = false,
                ["SistemaAudio"] = "Básico",
                ["GPSIntegrado"] = false,
                ["GarantiaMeses"] = 36           // duración en meses
            };
        }

        public void AddVehicle(Vehicle vehicle)
        {
            // Inyecta el año actual
            vehicle.Year = DateTime.Now.Year;

            // Añade todas las propiedades por defecto
            foreach (var kv in _defaults)
            {
                vehicle.ExtraProperties[kv.Key] = kv.Value;
            }

            // Delegar al repositorio subyacente
            _inner.AddVehicle(vehicle);
        }

        public Vehicle Find(string id)
            => _inner.Find(id);

        public ICollection<Vehicle> GetVehicles()
            => _inner.GetVehicles();
    }
}
