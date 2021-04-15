using System;
namespace ej_transporte
{
    public class Avion : Transporte
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
            Console.WriteLine("Estoy aterrizando...");
        }
        public override string ToString()
        {
            return "Avión";
        }
    }
}