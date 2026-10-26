using System;
using GestionVehiculos.Modelos;
using GestionVehiculos.Servicios;

namespace GestionVehiculos
{
    class Program
    {
        static GestorFlota gestor = new GestorFlota();

        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión y Renta de Vehículos";
            int opcion;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==================================================");
                Console.WriteLine("===== SISTEMA DE GESTIÓN Y RENTA DE VEHÍCULOS =====");
                Console.WriteLine("==================================================");
                Console.ResetColor();
                Console.WriteLine("1. Registrar vehículo");
                Console.WriteLine("2. Mostrar todos los vehículos");
                Console.WriteLine("3. Buscar vehículo por código");
                Console.WriteLine("4. Mostrar vehículos disponibles");
                Console.WriteLine("5. Mostrar vehículos rentados");
                Console.WriteLine("6. Cambiar estado");
                Console.WriteLine("7. Vehículo con mayor kilometraje");
                Console.WriteLine("8. Calcular precio promedio de renta");
                Console.WriteLine("9. Cantidad de vehículos por tipo");
                Console.WriteLine("10. Realizar mantenimiento");
                Console.WriteLine("11. Salir");
                Console.WriteLine("==================================================");

                opcion = LeerEnteroRango("Seleccione una opción (1-11): ", 1, 11);

                Console.Clear();
                EjecutarOpcion(opcion);

                if (opcion != 11)
                {
                    Console.WriteLine("\nPresione cualquier tecla para regresar al menú principal...");
                    Console.ReadKey();
                }

            } while (opcion != 11);

            Console.WriteLine("¡Gracias por utilizar el sistema!");
        }

        static void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    MenuRegistrarVehiculo();
                    break;
                case 2:
                    gestor.MostrarTodos();
                    break;
                case 3:
                    string codigoBuscar = LeerTextoNoVacio("Ingrese el código del vehículo a buscar: ");
                    var vehiculo = gestor.BuscarPorCodigo(codigoBuscar);
                    if (vehiculo != null) vehiculo.MostrarInformacion();
                    else Console.WriteLine("Vehículo no encontrado.");
                    break;
                case 4:
                    gestor.MostrarPorEstado("Disponible");
                    break;
                case 5:
                    gestor.MostrarPorEstado("Rentado");
                    break;
                case 6:
                    string codEstado = LeerTextoNoVacio("Ingrese el código del vehículo: ");
                    Console.WriteLine("Estados: 1. Disponible | 2. Rentado | 3. En Mantenimiento");
                    int opEstado = LeerEnteroRango("Seleccione nuevo estado: ", 1, 3);
                    string nuevoEstado = opEstado switch { 1 => "Disponible", 2 => "Rentado", 3 => "En Mantenimiento", _ => "Disponible" };
                    gestor.CambiarEstado(codEstado, nuevoEstado);
                    break;
                case 7:
                    gestor.ObtenerMayorKilometraje();
                    break;
                case 8:
                    Console.WriteLine($"El precio promedio de renta por día es: ${gestor.CalcularPrecioPromedio():F2}");
                    break;
                case 9:
                    gestor.ContarVehiculosPorTipo();
                    break;
                case 10:
                    string codMant = LeerTextoNoVacio("Ingrese el código del vehículo: ");
                    gestor.GestionarMantenimiento(codMant);
                    break;
                case 11:
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }
        }

        static void MenuRegistrarVehiculo()
        {
            Console.WriteLine("=== REGISTRO DE VEHÍCULO ===");
            Console.WriteLine("1. Automóvil | 2. Camioneta | 3. Motocicleta");
            int tipo = LeerEnteroRango("Seleccione el tipo: ", 1, 3);

            string codigo = LeerTextoNoVacio("Código: ");
            string marca = LeerTextoNoVacio("Marca: ");
            string modelo = LeerTextoNoVacio("Modelo: ");
            int anio = LeerEnteroRango("Año de fabricación: ", 1900, DateTime.Now.Year + 1);
            double kilometros = LeerDoublePositivo("Kilometraje actual: ");
            double precioRenta = LeerDoublePositivo("Precio de renta por día ($): ");

            switch (tipo)
            {
                case 1:
                    int puertas = LeerEnteroRango("Número de puertas: ", 1, 6);
                    string transmision = LeerTextoNoVacio("Transmisión (Manual/Automática): ");
                    string combustible = LeerTextoNoVacio("Combustible (Gasolina/Diésel/Híbrido): ");
                    bool aire = LeerBooleano("¿Tiene aire acondicionado? (s/n): ");
                    int pasAuto = LeerEnteroRango("Pasajeros: ", 1, 10);
                    gestor.RegistrarVehiculo(new Automovil(codigo, marca, modelo, anio, kilometros, precioRenta, puertas, transmision, combustible, aire, pasAuto));
                    break;
                case 2:
                    double carga = LeerDoublePositivo("Capacidad de carga (Toneladas): ");
                    string traccion = LeerTextoNoVacio("Tracción (4x2/4x4): ");
                    bool cabina = LeerBooleano("¿Tiene doble cabina? (s/n): ");
                    int pasCam = LeerEnteroRango("Pasajeros: ", 1, 15);
                    gestor.RegistrarVehiculo(new Camioneta(codigo, marca, modelo, anio, kilometros, precioRenta, carga, traccion, cabina, pasCam));
                    break;
                case 3:
                    int cilindrada = LeerEnteroRango("Cilindrada (cc): ", 50, 2500);
                    string tipoMoto = LeerTextoNoVacio("Tipo (Scooter/Enduro/Pistera): ");
                    bool baul = LeerBooleano("¿Tiene baúl? (s/n): ");
                    int cascos = LeerEnteroRango("Cascos incluidos: ", 0, 4);
                    gestor.RegistrarVehiculo(new Motocicleta(codigo, marca, modelo, anio, kilometros, precioRenta, cilindrada, tipoMoto, baul, cascos));
                    break;
            }
        }

        public static int LeerEnteroRango(string mensaje, int min, int max)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Entrada no válida. Ingrese un entero entre {min} y {max}: ");
                Console.ResetColor();
            }
            return valor;
        }

        public static double LeerDoublePositivo(string mensaje)
        {
            double valor;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Entrada no válida. Ingrese un número positivo: ");
                Console.ResetColor();
            }
            return valor;
        }

        public static string LeerTextoNoVacio(string mensaje)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(entrada))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Campo obligatorio. Ingrese nuevamente: ");
                Console.ResetColor();
                entrada = Console.ReadLine();
            }
            return entrada.Trim();
        }

        public static bool LeerBooleano(string mensaje)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine()?.Trim().ToLower();
            while (entrada != "s" && entrada != "n" && entrada != "si" && entrada != "no")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Responda 's' o 'n': ");
                Console.ResetColor();
                entrada = Console.ReadLine()?.Trim().ToLower();
            }
            return entrada == "s" || entrada == "si";
        }
    }
}