using MvvmHelpers;
using SAbadEvaluacion3P.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SAbadEvaluacion3P.ModelViews
{
    public class SACountryDetalle : BaseViewModel
    {
        public SACountry Country { get; set; }

        public SACountryDetalle(SACountry country)
        {
            Country = country;
        }
        private readonly SACountryService _countryService;
        private SACountry _selectedCountry;
        private string _countryName;

        public string CountryName
        {
            get => _countryName;
            set
            {
                if (_countryName != value)
                {
                    _countryName = value;
                    OnPropertyChanged();
                }
            }
        }

        public SACountry SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged();
                }
            }
        }

        // Comando para cargar el país
        public ICommand LoadCountryCommand { get; }

        public SACountryDetalle()
        {
            _countryService = new SACountryService();
            LoadCountryCommand = new Command(async () => await LoadCountryAsync());
        }

        private async Task LoadCountryAsync()
        {
            if (string.IsNullOrWhiteSpace(CountryName))
            {
                // Manejo de error si no se ingresa un nombre de país
                return;
            }

            // Llamar al servicio para obtener la información del país
            var country = await _countryService.GetCountryByNameAsync(CountryName);

            // Asignar la respuesta al SelectedCountry para mostrarla en la vista
            if (country != null)
            {
                SelectedCountry = country;
            }
            else
            {
                // Manejar el caso donde no se encuentra el país (mostrar mensaje de error)
                await App.Current.MainPage.DisplayAlert("Error", "No se encontró el país.", "OK");
            }
        }
    }
}
