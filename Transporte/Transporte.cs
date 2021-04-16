namespace ej_transporte
{
    public abstract class Transporte
    {
        private int pasajeros;
        public Transporte(int pasajeros)
        {
            this.pasajeros = pasajeros;
        }
        public abstract void Avanzar();
        public abstract void Detenerse();
        public int Pasajeros
        {
            get{ return pasajeros; }
        }
    }
}