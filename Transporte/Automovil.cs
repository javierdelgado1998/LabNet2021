using System;
namespace ej_transporte
{
    public class Automovil : Transporte
    {
        public Automovil(int pasajeros) : base(pasajeros)
        {

        }
        public override void Avanzar()
        {
            Console.WriteLine("Estoy acelerando...");
        }
        public override void Detenerse()
        {
            Console.WriteLine("Estoy frenando...");
        }
        public override string ToString()
        {
            return "Automóvil";
        }
    }
}