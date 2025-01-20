using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAbadEvaluacion3P
{
    public class SACountryService
    {
        private readonly HttpClient _httpClient;

        public SACountryService() {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://restcountries.com/v3.1/all")
            };

        }


    }
}
