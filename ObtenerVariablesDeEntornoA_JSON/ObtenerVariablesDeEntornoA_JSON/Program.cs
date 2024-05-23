namespace ObtenerVariablesDeEntornoA_JSON
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;

    class Program
    {
        [DataContract]
        class EnvironmentVariables
        {
            [DataMember]
            public Dictionary<string, string> Variables { get; set; }
        }

        static void Main(string[] args)
        {
            var environmentVariables = new EnvironmentVariables
            {
                Variables = new Dictionary<string, string>()
            };

            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            {
                environmentVariables.Variables[(string)de.Key] = (string)de.Value;
            }

            var jsonSerializer = new DataContractJsonSerializer(typeof(EnvironmentVariables));

            using (var memoryStream = new MemoryStream())
            {
                jsonSerializer.WriteObject(memoryStream, environmentVariables);
                string json = Encoding.UTF8.GetString(memoryStream.ToArray());

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "environmentVariables.json");
                File.WriteAllText(outputPath, json);

                Console.WriteLine($"El archivo JSON con las variables de entorno se ha generado en: {outputPath}");
            }
        }
    }

}
