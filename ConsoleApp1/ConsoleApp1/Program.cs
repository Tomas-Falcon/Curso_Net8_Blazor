namespace ConsoleApp1
{
    public class Program
    {

        
        static void Main(string[] args)
        {

            Hipopotamo hipopotamo = new Hipopotamo();
            LagartoJuancho lagartoJuancho = new LagartoJuancho();

            hipopotamo.Pelliscado += lagartoJuancho.ManejarPellizco;

            hipopotamo.Pelliscar();

        }

    }
}

