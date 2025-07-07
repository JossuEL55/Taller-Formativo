using DesignPatterns.ModelBuilders; // Proveedor del Builder para construir instancias de Car
using DesignPatterns.Models;        // Definici�n de Vehicle y Car

namespace DesignPatterns.Factories
{
    // F�brica concreta para crear veh�culos Ford Escape
    public class FordEscapeFactory : CarFactory
    {
        // Nombre del modelo usado como clave en el provider
        public override string ModelName => "Escape";

        // Construye y devuelve una instancia de Escape usando el Builder
        public override Vehicle Create()
        {
            return new CarModelBuilder()
                .setModel("Escape")   // Define el modelo
                .setColor("red")      // Define el color
                .setBrand("Ford")     // Define la marca
                .build();             // Ejecuta la construcci�n final
        }
    }
}
