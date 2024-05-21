using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://petstore.swagger.io/v2/pet";

        string jsonBody = @"{
            ""id"": 0,
            ""name"": ""Mi 1ra chamba the DOG""
        }";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                //si devuelve un 200, exitoso
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("La mascota fue creada exitosamente.");
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("\nJSON de la respuesta:");
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"Error al crear la mascota. Código de estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
