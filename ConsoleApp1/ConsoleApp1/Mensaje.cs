using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Mensaje
    {
        public string Texto { get; set; }

        public Mensaje(string texto)
        {
            Texto = texto;
        }
    }

    public class EventMensajeArgs: EventArgs
    {
        public Mensaje? Mensaje { get; set; }
    }
}
