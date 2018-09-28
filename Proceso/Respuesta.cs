using System;

namespace Proceso
{
    public class Respuesta
    {
        public Respuesta()
        {
            Mensaje = "Iniciado";
            Proceso = "NoCargado";
            numeroRegistros = 0;
        }

        public String Mensaje { get; set; }
        public String Proceso { get; set; }
        public int numeroRegistros { get; set; }
    } // public class Respuesta
}//namespace Proceso {
