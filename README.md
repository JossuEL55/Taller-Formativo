# Taller de Patrones C# – Codificando Con Patrones

**Fecha:** 23 de junio de 2025

Este repositorio contiene la implementación del taller formativo, donde:

- Se completó la funcionalidad de **agregar vehículos** (Mustang, Explorer, Escape) en la Home Page.  
- Se usó un **Factory Method** (`CarFactoryProvider` + clases `FordXXXFactory`) para aislar la creación de cada modelo.  
- Para pruebas sin base de datos, se implementó un repositorio en memoria (`MyVehiclesRepository`) y se decoró con **Decorator** (`DefaultPropertiesVehicleRepository`) para inyectar el año actual y 20 propiedades por defecto en cada vehículo.  
- El código sigue principios **SOLID** y buenas prácticas, con comentarios en cada clase/método.

## Estructura del proyecto
/DesignPatterns
/Controllers → HomeController con rutas genéricas (Add, StartEngine, …)
/Factories → Factory Method para cada modelo de Car
/ModelBuilders → Builder para ensamblar objetos Car con extraProperties
/Models → Vehicle base, Car, Motocycle, ViewModels
/Repositories → IVehicleRepository, MyVehiclesRepository, DBVehicleRepository, Decorator
/Infrastructure → Registro de servicios y decoración en DI

## Cómo ejecutar

1. Clona el repositorio y abre la solución `DesignPatterns.sln` en Visual Studio.  
2. Asegúrate de tener el perfil **IIS Express** (o tu servidor local) y ejecuta la aplicación.  
3. Navega a la Home Page y usa los enlaces **Add Mustang**, **Add Explorer**, **Add Escape**.  
4. Observa cómo cada vehículo aparece con año, color, modelo y las propiedades inyectadas.

Este proyecto ya está listo para:

- Introducir más modelos (solo crea una nueva fábrica y regístrala en DI).  
- Conectar a base de datos cuando el esquema esté disponible.  

Cualquier duda, revisa los comentarios en el código.  
