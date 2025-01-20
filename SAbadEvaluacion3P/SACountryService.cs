using Newtonsoft.Json;
using SAbadEvaluacion3P.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SAbadEvaluacion3P
{
    public class SACountryService
    {
        private readonly HttpClient _httpClient;

        public SACountryService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<SACountry>> SAGetCountriesAsync()
        {
            try
            {
                var url = "https://restcountries.com/v3.1/all"; // URL de la API
                var response = await _httpClient.GetStringAsync(url);

                // Verifica que la respuesta no esté vacía
                if (string.IsNullOrWhiteSpace(response))
                {
                    throw new Exception("Respuesta vacía de la API.");
                }

                // Deserializa la respuesta JSON a una lista de países
                var countries = JsonConvert.DeserializeObject<List<SACountry>>(response);

                return countries;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error de solicitud HTTP: {httpEx.Message}");
                if (httpEx.InnerException != null)
                {
                    Console.WriteLine($"Detalles internos: {httpEx.InnerException.Message}");
                }
                return new List<SACountry>(); // Devuelve una lista vacía si hay un error
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener países: {ex.Message}");
                return new List<SACountry>(); // Devuelve una lista vacía si hay un error
            }
        


    }
    }
}
