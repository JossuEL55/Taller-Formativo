using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public abstract class Vehicle : IVehicle
    {
        // Indica internamente si el motor está encendido (true) o apagado (false)
        private bool _isEngineOn { get; set; }

        // Identificador único de este vehículo
        public readonly Guid ID;

        // Número de neumáticos (se sobreescribe en las subclases)
        public virtual int Tires { get; set; }

        // Propiedades básicas del vehículo
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        // Cantidad de gasolina actual
        public double Gas { get; set; }

        // Capacidad máxima de gasolina
        public double FuelLimit { get; set; }

        // Año de fabricación o modelo del vehículo
        public int Year { get; set; }

        // Diccionario para propiedades adicionales (decorator o builder)
        public Dictionary<string, object> ExtraProperties { get; set; } = new();

        // Constructor principal: inicializa ID y valores básicos
        public Vehicle(string color, string brand, string model, double fuelLimit = 10)
        {
            ID = Guid.NewGuid();
            Color = color;
            Brand = brand;
            Model = model;
            FuelLimit = fuelLimit;
        }

        // Añade 0.1 unidades de combustible;
        // si supera FuelLimit, lanza excepción "Gas Full"
        public void AddGas()
        {
            if (Gas <= FuelLimit)
            {
                Gas += 0.1;
            }
            else
            {
                throw new Exception("Gas Full");
            }
        }

        // Arranca el motor si está apagado y hay gasolina;
        // lanza excepción si ya está encendido o si no hay gasolina
        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on");
            }

            if (NeedsGas())
            {
                throw new Exception("No enoguht gas. You need to go to Gas Station");
            }

            _isEngineOn = true;
        }

        // Devuelve true si no hay gasolina (Gas <= 0)
        public bool NeedsGas()
        {
            return !(Gas > 0);
        }

        // Indica si el motor está encendido
        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        // Detiene el motor si estaba encendido;
        // lanza excepción si ya estaba apagado
        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Enigne already stopped");
            }

            _isEngineOn = false;
        }
    }
}
