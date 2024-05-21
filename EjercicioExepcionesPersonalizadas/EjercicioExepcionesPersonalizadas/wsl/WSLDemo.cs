using EjercicioExepcionesPersonalizadas.brl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExepcionesPersonalizadas.wsl
{

    // Clase WslDemo con el método wslAlta
    public class WSLDemo
    {
        private BRLDemo brlDemo;

        public WSLDemo()
        {
            brlDemo = new BRLDemo();
        }

        public void wslAlta()
        {
            try
            {
                brlDemo.brlAlta();
            }
            catch (CustomDalException ex)
            {
                // Manejar la excepción aquí
                Console.WriteLine("Excepción manejada en WSL: " + ex.Message);
            }
        }
    }
}
