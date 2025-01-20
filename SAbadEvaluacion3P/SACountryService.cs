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
                // URL de la API Rest Countries (ejemplo de la API pública)
                string url = "https://restcountries.com/v3.1/all";

                // Realizar la solicitud HTTP GET
                var response = await _httpClient.GetStringAsync(url);

                // Deserializar el JSON en una lista de objetos Country
                var countries = JsonConvert.DeserializeObject<List<SACountry>>(response);

                return countries;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener países: {ex.Message}");
                return new List<SACountry>();
            }
        }


    }
}
