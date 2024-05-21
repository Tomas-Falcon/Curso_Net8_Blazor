using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate void GritarEventHandler(Hipopotamo hipopotamo, EventMensajeArgs evArgs);
    public class Hipopotamo
    {
        // Evento basado en el delegado
        public event GritarEventHandler Pelliscado;

        // Método para lanzar el evento
        public void Pelliscar()
        {
            Console.WriteLine("¡El Hipopótamo fue pelliscado!");
            // Creamos un nuevo mensaje
            Mensaje mensaje = new Mensaje("¡Auch!");
            EventMensajeArgs msjArgs = new EventMensajeArgs();
            msjArgs.Mensaje = mensaje;
            // Invocamos el evento pasando el mensaje como argumento
            Pelliscado?.Invoke(this, msjArgs);
        }
    }
}
