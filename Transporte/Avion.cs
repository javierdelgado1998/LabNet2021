using System;
namespace ej_transporte
{
    public class Avion : Transporte, IAereo
    {
        public Avion(int pasajeros) : base(pasajeros)
        {

        }
        public override void Avanzar()
        {
            Console.WriteLine("Estoy volando...");
        }
        public override void Detenerse()
        {
            Console.WriteLine("Estoy descendiendo...");
        }
        public override string ToString()
        {
            return "Avión";
        }
        public void Despegar()
        {
            Console.WriteLine("Estoy despegando...");
        }
        public void Aterrizar()
        {
            Console.WriteLine("Estoy aterrizando...");
        }
    }
}