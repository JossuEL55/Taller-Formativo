using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Factories
{
    public class CarFactoryProvider
    {
        // Mapea el nombre de modelo (clave) a su fábrica correspondiente
        private readonly IDictionary<string, CarFactory> _factories;

        public CarFactoryProvider(IEnumerable<CarFactory> factories)
        {
            // Construye el diccionario usando ModelName como clave
            _factories = factories.ToDictionary(
                f => f.ModelName,
                StringComparer.OrdinalIgnoreCase // busquedas case-insensitive
            );
        }

        public CarFactory Get(string model)
        {
            // Si existe la fábrica para este modelo, la retorna
            if (_factories.TryGetValue(model, out var factory))
                return factory;

            // Si no está registrada, lanza excepción explicativa
            throw new NotSupportedException($"Modelo '{model}' no soportado.");
        }
    }
}
