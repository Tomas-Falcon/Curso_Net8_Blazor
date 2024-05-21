using EjercicioExepcionesPersonalizadas.wsl;
using Serilog;

namespace EjercicioExepcionesPersonalizadas
{

    
    // Definimos la excepción personalizada
    public class CustomDalException : Exception
    {
        public CustomDalException(string message) : base(message) { }
    }

    // Clase DalDemo con el método dalAlta
    public class DalDemo
    {
        public void dalAlta()
        {
            try
            {
                // Simulamos un error que lanza la excepción personalizada
                throw new CustomDalException("Error en la capa DAL");
            }
            catch (CustomDalException ex)
            {
                // Podemos hacer algo con la excepción aquí si es necesario
                // y luego la volvemos a lanzar para que se maneje en el siguiente nivel
                throw;
            }
        }
    }

    // Clase BrlDemo con el método brlAlta
    public class BrlDemo
    {
        private DalDemo dalDemo;

        public BrlDemo()
        {
            dalDemo = new DalDemo();
        }

        public void brlAlta()
        {
            try
            {
                dalDemo.dalAlta();
            }
            catch (CustomDalException ex)
            {
                // Manejar la excepción y luego propagarla
                Console.WriteLine("Excepción manejada en BRL: " + ex.Message);
                throw;
            }
        }
    }


    // Programa principal para ejecutar el ejemplo
    public class Program
    {
        public static void Main(string[] args)
        {
            using var log = new Serilog.LoggerConfiguration()
                .WriteTo
                .Console()
                .CreateLogger();
            Log.Logger = log;

            Log.Information("The global logger has been configured");

            WSLDemo wslDemo = new WSLDemo();
            wslDemo.wslAlta();
        }
    }

}
