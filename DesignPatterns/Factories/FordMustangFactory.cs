using DesignPatterns.ModelBuilders; // Builder encargado de armar instancias de Car
using DesignPatterns.Models;        // Contiene Vehicle y Car

namespace DesignPatterns.Factories
{
    // Fábrica concreta para crear instancias de Ford Mustang
    public class FordMustangFactory : CarFactory
    {
        // Clave identificadora usada por el provider
        public override string ModelName => "Mustang";

        // Construye y devuelve una instancia configurada de Mustang
        public override Vehicle Create()
        {
            return new CarModelBuilder()
                .setModel("Mustang") // Define el modelo
                .setColor("red")     // Define el color por defecto
                .setBrand("Ford")    // Define la marca por defecto
                .build();            // Realiza la construcción del objeto
        }
    }
}
