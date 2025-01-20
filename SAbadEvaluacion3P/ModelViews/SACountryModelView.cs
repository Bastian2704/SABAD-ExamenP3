using MvvmHelpers;
using SAbadEvaluacion3P.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAbadEvaluacion3P.ModelViews
{
    public class SACountryModelView : BaseViewModel
    {
        private readonly SACountryService _countryService;

        // Propiedad que representará la lista de países
        public ObservableCollection<SACountry> Countries { get; set; }

        // Constructor
        public SACountryModelView()
        {
            _countryService = new SACountryService();
            Countries = new ObservableCollection<SACountry>();
            LoadCountriesCommand = new Command(async () => await LoadCountries());
        }

        // Comando para cargar los países
        public Command LoadCountriesCommand { get; }

        // Método para cargar los países desde la API
        private async Task LoadCountries()
        {
            var countries = await _countryService.SAGetCountriesAsync();
            Countries.Clear();
            foreach (var country in countries)
            {
                Countries.Add(country);
            }
        }
    }
}
