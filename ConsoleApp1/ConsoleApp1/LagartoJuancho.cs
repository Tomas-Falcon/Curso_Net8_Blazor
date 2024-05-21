using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LagartoJuancho
    {

        public void ManejarPellizco(Hipopotamo hp, EventMensajeArgs args)
        {
            Console.WriteLine($"LagartoJuancho escucha el mensaje de: {hp}");
            Console.WriteLine($"El mensaje es: {args.Mensaje.Texto}");
        }

    }
}
