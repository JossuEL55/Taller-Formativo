using DesignPatterns.ModelBuilders; // Para usar el Builder que construye instancias de Car
using DesignPatterns.Models;        // Contiene la definición de Vehicle y Car

namespace DesignPatterns.Factories
{
    // Fábrica concreta para crear vehículos Ford Explorer
    public class FordExplorerFactory : CarFactory
    {
        // Clave usada por el provider para identificar esta fábrica
        public override string ModelName => "Explorer";

        // Construye y devuelve una instancia configurada de Explorer
        public override Vehicle Create()
        {
            return new CarModelBuilder()
                .setModel("Explorer") // Define el modelo específico
                .setColor("black")    // Define el color por defecto
                .setBrand("Ford")     // Define la marca por defecto
                .build();             // Ejecuta la construcción final del objeto
        }
    }
}
