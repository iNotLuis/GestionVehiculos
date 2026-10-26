using System;
using System.Collections.Generic;
using System.Linq;
using GestionVehiculos.Modelos;

namespace GestionVehiculos.Servicios
{
    public class GestorFlota
    {
        private readonly List<Vehiculo> flota = new List<Vehiculo>();

        public GestorFlota()
        {
            flota.Add(new Automovil("AUT01", "Toyota", "Corolla", 2022, 25000, 45.0, 4, "Automática", "Gasolina", true, 5));
            flota.Add(new Camioneta("CAM01", "Ford", "Ranger", 2021, 48000, 85.0, 1.2, "4x4", true, 5));
            flota.Add(new Motocicleta("MOT01", "Yamaha", "MT-07", 2023, 12000, 35.0, 689, "Pistera", true, 2));
        }

        public bool RegistrarVehiculo(Vehiculo vehiculo)
        {
            if (BuscarPorCodigo(vehiculo.Codigo) != null)
            {
                Console.WriteLine($"Error: Ya existe un vehículo registrado con el código '{vehiculo.Codigo}'.");
                return false;
            }

            flota.Add(vehiculo);
            Console.WriteLine("Vehículo registrado exitosamente.");
            return true;
        }

        public void MostrarTodos()
        {
            if (!ValidarFlotaNoVacia()) return;

            Console.WriteLine("\n=================== LISTA DE VEHÍCULOS ===================");
            foreach (var v in flota)
            {
                v.MostrarInformacion();
            }
        }

        public Vehiculo? BuscarPorCodigo(string codigo)
        {
            return flota.FirstOrDefault(v => v.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        public void MostrarPorEstado(string estado)
        {
            var filtrados = flota.Where(v => v.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filtrados.Count == 0)
            {
                Console.WriteLine($"No hay vehículos en estado '{estado}'.");
                return;
            }

            Console.WriteLine($"\n================ VEHÍCULOS EN ESTADO: {estado.ToUpper()} ================");
            foreach (var v in filtrados)
            {
                v.MostrarInformacion();
            }
        }

        public bool CambiarEstado(string codigo, string nuevoEstado)
        {
            var vehiculo = BuscarPorCodigo(codigo);
            if (vehiculo == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return false;
            }

            vehiculo.Estado = nuevoEstado;
            Console.WriteLine($"El estado del vehículo {codigo} se actualizó a '{nuevoEstado}'.");
            return true;
        }

        public void ObtenerMayorKilometraje()
        {
            if (!ValidarFlotaNoVacia()) return;

            Vehiculo mayor = flota[0];
            foreach (var v in flota)
            {
                if (v.Kilometros > mayor.Kilometros)
                {
                    mayor = v;
                }
            }

            Console.WriteLine("\n================ VEHÍCULO CON MAYOR KILOMETRAJE ================");
            mayor.MostrarInformacion();
        }

        public double CalcularPrecioPromedio()
        {
            if (flota.Count == 0) return 0.0;
            return flota.Average(v => v.PrecioRenta);
        }

        public void ContarVehiculosPorTipo()
        {
            int autos = 0, camionetas = 0, motos = 0;

            foreach (var v in flota)
            {
                if (v is Automovil) autos++;
                else if (v is Camioneta) camionetas++;
                else if (v is Motocicleta) motos++;
            }

            Console.WriteLine("\n================ CANTIDAD DE VEHÍCULOS POR TIPO ================");
            Console.WriteLine($"Automóviles : {autos}");
            Console.WriteLine($"Camionetas  : {camionetas}");
            Console.WriteLine($"Motocicletas: {motos}");
            Console.WriteLine($"Total Flota : {flota.Count}");
        }

        public void GestionarMantenimiento(string codigo)
        {
            var vehiculo = BuscarPorCodigo(codigo);
            if (vehiculo == null)
            {
                Console.WriteLine("Vehículo no encontrado.");
                return;
            }

            Console.WriteLine("\n--- Opciones de Mantenimiento ---");
            Console.WriteLine("1. Consultar diagnóstico de mantenimiento");
            Console.WriteLine("2. Ejecutar mantenimiento programado");

            Console.Write("Seleccione una opción (1-2): ");
            if (int.TryParse(Console.ReadLine(), out int opcion) && opcion == 1)
            {
                vehiculo.ConsultarMantenimiento();
            }
            else
            {
                vehiculo.RealizarMantenimiento();
            }
        }

        private bool ValidarFlotaNoVacia()
        {
            if (flota.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados en la flota.");
                return false;
            }
            return true;
        }
    }
}