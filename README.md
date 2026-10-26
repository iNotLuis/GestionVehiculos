# Sistema de Gestión y Renta de Vehículos

Aplicación de consola desarrollada en C# (.NET 8) orientada a la administración y alquiler de una flota heterogénea de vehículos (Automóviles, Camionetas y Motocicletas).

## Integrantes y Distribución de Tareas
| Integrante | Rol / Componente Desarrollado |
| :--- | :--- |
| **Luis Restrepo** | Configuración del Proyecto (.csproj) e Interfaz (`IMantenimiento`) |
| **Owen Mora** | Jerarquía de Modelos (`Vehiculo`, `Automovil`, `Camioneta`, `Motocicleta`) |
| **Dairo Segura** | Servicios y Lógica de Negocio (`GestorFlota`) |
| **Angelo Charris** | Menú Interactivo (`Program.cs`) y Documentación (`README.md`) |

## Conceptos POO Aplicados
- **Abstracción y Encapsulamiento:** Clase base `Vehiculo` con propiedades auto-implementadas.
- **Herencia:** Clases `Automovil`, `Camioneta` y `Motocicleta` derivan de `Vehiculo`.
- **Polimorfismo:** Sobreescritura (`override`) de `MostrarInformacion()` y procesamiento heterogéneo en `List<Vehiculo>`.
- **Interfaces:** Implementación de `IMantenimiento` para desacoplar operaciones de servicio.
- **Verificación de Tipos:** Uso del operador `is` para conteo polimórfico de objetos.

## Ejecución
```bash
dotnet build
dotnet run# Sistema de Gestión y Renta de Vehículos

Aplicación de consola desarrollada en C# (.NET 8) orientada a la administración y alquiler de una flota heterogénea de vehículos (Automóviles, Camionetas y Motocicletas).

## Integrantes y Distribución de Tareas
| Integrante | Rol / Componente Desarrollado |
| :--- | :--- |
| **Integrante 1** | Configuración del Proyecto (.csproj) e Interfaz (`IMantenimiento`) |
| **Integrante 2** | Jerarquía de Modelos (`Vehiculo`, `Automovil`, `Camioneta`, `Motocicleta`) |
| **Integrante 3** | Servicios y Lógica de Negocio (`GestorFlota`) |
| **Integrante 4** | Menú Interactivo (`Program.cs`) y Documentación (`README.md`) |

## Conceptos POO Aplicados
- **Abstracción y Encapsulamiento:** Clase base `Vehiculo` con propiedades auto-implementadas.
- **Herencia:** Clases `Automovil`, `Camioneta` y `Motocicleta` derivan de `Vehiculo`.
- **Polimorfismo:** Sobreescritura (`override`) de `MostrarInformacion()` y procesamiento heterogéneo en `List<Vehiculo>`.
- **Interfaces:** Implementación de `IMantenimiento` para desacoplar operaciones de servicio.
- **Verificación de Tipos:** Uso del operador `is` para conteo polimórfico de objetos.

## Ejecución
```bash
dotnet build
dotnet run