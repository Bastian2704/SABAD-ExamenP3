namespace SAbadEvaluacion3P.Views;

using SAbadEvaluacion3P.Models;
using SAbadEvaluacion3P.ModelViews;

public partial class SACountryView : ContentPage
{
	public SACountryView()
	{
		InitializeComponent();
        BindingContext = new SACountryModelView();
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Verificamos si se ha seleccionado un país
        if (e.SelectedItem is SACountry selectedCountry)
        {
            // Navegar a la página de detalles pasando el nombre del país como parámetro
            await Shell.Current.GoToAsync($"///countrydetails?name={selectedCountry.Name.Common}");
        }

        // Deseleccionar el item después de la navegación
        ((ListView)sender).SelectedItem = null;
    }
}