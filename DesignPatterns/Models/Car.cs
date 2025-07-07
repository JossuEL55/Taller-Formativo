using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    // Representa un automóvil específico, hereda de Vehicle
    public class Car : Vehicle
    {
        // Inicializa los datos básicos del automóvil
        // fuelLimit está fijo en 10 (litros) para todos los Car
        public Car(string color, string brand, string model, int year)
            : base(color, brand, model, fuelLimit: 10)
        {
            Year = year; // Asigna el año al vehículo
        }

        // Define la cantidad de ruedas que tiene un automóvil
        public override int Tires => 4;
    }
}
