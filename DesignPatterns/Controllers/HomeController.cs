using System;
using System.Diagnostics;
using DesignPatterns.Factories;        // Para resolver la fábrica de vehículos
using DesignPatterns.Models;           // Contiene la definición de Vehicle y HomeViewModel
using DesignPatterns.Repositories;     // Para IVehicleRepository y su decorator
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesignPatterns.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;  // Repositorio inyectado (con decorator)
        private readonly CarFactoryProvider _factoryProvider;    // Resuelve la fábrica adecuada según modelo
        private readonly ILogger<HomeController> _logger;        // ILogger para registro de eventos

        public HomeController(
            IVehicleRepository vehicleRepository,
            CarFactoryProvider factoryProvider,
            ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _factoryProvider = factoryProvider;
            _logger = logger;
        }

        // Acción principal: muestra la lista de vehículos y un posible mensaje de error
        public IActionResult Index(string error = null)
        {
            if (!string.IsNullOrEmpty(error))
                ViewBag.ErrorMessage = error;  // Pasa el mensaje de error a la vista si existe

            var vm = new HomeViewModel
            {
                Vehicles = _vehicleRepository.GetVehicles()  // Obtiene todos los vehículos almacenados
            };
            return View(vm);
        }

        // Acción genérica para agregar un vehículo según su modelo
        [HttpGet]
        public IActionResult Add(string model)
        {
            // Resuelve la fábrica de vehículos por nombre (Mustang, Explorer, Escape, etc.)
            var factory = _factoryProvider.Get(model);
            // Crea la instancia de Vehicle usando el Builder interno de la fábrica
            var vehicle = factory.Create();
            // Guarda el vehículo (aquí se inyectan año y propiedades por defecto)
            _vehicleRepository.AddVehicle(vehicle);
            // Redirige a Index para refrescar la lista
            return RedirectToAction(nameof(Index));
        }

        // Arranca el motor del vehículo identificado por 'id'
        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StartEngine();  // Lógica propia de Vehicle
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // En caso de error, redirige a Index pasando el mensaje
                return RedirectToAction(nameof(Index), new { error = ex.Message });
            }
        }

        // Agrega gas al vehículo identificado por 'id'
        [HttpGet]
        public IActionResult AddGas(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.AddGas();  // Incrementa el combustible
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), new { error = ex.Message });
            }
        }

        // Detiene el motor del vehículo identificado por 'id'
        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StopEngine();  // Detiene el motor
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index), new { error = ex.Message });
            }
        }

        // Página de privacidad (acción sin lógica adicional)
        public IActionResult Privacy()
            => View();

        // Página de error estándar con caché desactivado
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}
