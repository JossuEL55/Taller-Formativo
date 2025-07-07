using System;
using System.Collections.Generic;
using DesignPatterns.Models;

namespace DesignPatterns.ModelBuilders
{
    // Builder para crear instancias de Car con configuración fluida
    public class CarModelBuilder
    {
        // Valores por defecto
        private string color = "red";
        private string brand = "Ford";
        private string model = "Mustang";
        private int year = DateTime.Now.Year;
        private readonly Dictionary<string, object> _extraProperties = new();

        // Establece el color del automóvil
        public CarModelBuilder setColor(string color)
        {
            this.color = color;
            return this;
        }

        // Establece la marca del automóvil
        public CarModelBuilder setBrand(string brand)
        {
            this.brand = brand;
            return this;
        }

        // Establece el modelo del automóvil
        public CarModelBuilder setModel(string model)
        {
            this.model = model;
            return this;
        }

        // Establece el año del automóvil
        public CarModelBuilder setYear(int year)
        {
            this.year = year;
            return this;
        }

        // Agrega una propiedad adicional al vehículo
        public CarModelBuilder AddProperty(string key, object value)
        {
            _extraProperties[key] = value;
            return this;
        }

        // Construye la instancia de Car y aplica las propiedades adicionales
        public Vehicle build()
        {
            var car = new Car(color, brand, model, year);
            foreach (var kv in _extraProperties)
            {
                car.ExtraProperties[kv.Key] = kv.Value;
            }
            return car;
        }
    }
}
