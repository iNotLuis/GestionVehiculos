using System;

namespace GestionVehiculos.Modelos
{
    public class Motocicleta : Vehiculo
    {
        public int Cilindrada { get; set; }
        public string TipoMotocicleta { get; set; }
        public bool TieneBaul { get; set; }
        public int NumeroCascos { get; set; }

        public Motocicleta(string codigo, string marca, string modelo, int anio, double kilometros, double precioRenta,
                           int cilindrada, string tipoMotocicleta, bool tieneBaul, int numeroCascos)
            : base(codigo, marca, modelo, anio, "Motocicleta", kilometros, precioRenta)
        {
            Cilindrada = cilindrada;
            TipoMotocicleta = tipoMotocicleta;
            TieneBaul = tieneBaul;
            NumeroCascos = numeroCascos;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            string baul = TieneBaul ? "Sí" : "No";
            Console.WriteLine($"Detalles: Cilindrada: {Cilindrada} cc | Tipo: {TipoMotocicleta} | Baúl: {baul} | Cascos: {NumeroCascos}");
        }
    }
}