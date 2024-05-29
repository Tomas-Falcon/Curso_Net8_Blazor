using consolebdd.Data;
using consolebdd.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace consolebdd.App
{
    public class Program
    {
        public static IConfigurationRoot? Configuration { get; set; }

        public static void Main(string[] args)
        {
            ReadConfiguration();

            using (var db = new SchoolContext())
            {
                Console.WriteLine("Creando base de datos...\n");
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Menú:");
                    Console.WriteLine("1. Agregar Estudiante");
                    Console.WriteLine("2. Listar Estudiantes");
                    Console.WriteLine("3. Salir");
                    Console.Write("Selecciona una opción: ");
                    var input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddStudent(db);
                            break;
                        case "2":
                            ListStudents(db);
                            break;
                        case "3":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida, por favor intenta de nuevo.");
                            break;
                    }
                }
            }
        }

        private static void ReadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            ConnectionStrings.DefaultConnection = Configuration["DefaultConnection"];

            Console.WriteLine("Configuración\n");
            Console.WriteLine($@"cadena de conexión (defaultConnection) = ""{ConnectionStrings.DefaultConnection}""");
            Console.WriteLine();
        }

        private static void AddStudent(SchoolContext db)
        {
            Console.Write("Ingresa el nombre: ");
            string firstName = Console.ReadLine();

            Console.Write("Ingresa el apellido: ");
            string lastName = Console.ReadLine();

            Console.Write("Ingresa la fecha de inscripción (yyyy-MM-dd): ");
            DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());

            var student = new Student
            {
                FirstMidName = firstName,
                LastName = lastName,
                EnrollmentDate = enrollmentDate
            };

            db.Students.Add(student);
            db.SaveChanges();
            Console.WriteLine("Estudiante agregado exitosamente.");
        }


        private static void ListStudents(SchoolContext db)
        {
            var students = db.Students.ToList();
            if (students.Any())
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Nombre: {student.FullName}, Fecha de inscripción: {student.EnrollmentDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No hay datos de estudiantes.");
                Console.WriteLine("Serás redirigido al menú principal.");
            }
        }
    }
}
