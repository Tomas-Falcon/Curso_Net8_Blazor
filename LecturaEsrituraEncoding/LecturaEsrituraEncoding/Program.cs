using System;
using System.IO;
using System.Text;

namespace LecturaEsrituraEncoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "hebreoSText.txt";
            string hebrewText = "Hola mundoñ";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding hebrewEncoding;
            
            
            try
            {
                hebrewEncoding = Encoding.GetEncoding("ISO-8859-8");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("La codificación ISO-8859-8 no está disponible en este sistema.");
                return;
            }
            using (StreamWriter writer = new StreamWriter(filePath, false, hebrewEncoding))
            {
                writer.WriteLine(hebrewText);
            }
            using (StreamReader reader = new StreamReader(filePath, hebrewEncoding))
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine("Contenido del archivo:");
                Console.WriteLine(fileContent);
            }
            if (File.Exists(filePath))
            {
                Console.WriteLine($"\nEl archivo '{filePath}' fue creado y leído correctamente.");
            }
            else
            {
                Console.WriteLine($"\nHubo un problema al crear o leer el archivo '{filePath}'.");
            }
        }
    }
}
