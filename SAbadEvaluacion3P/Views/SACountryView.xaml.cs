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
        // Verificamos si se ha seleccionado un pa�s
        if (e.SelectedItem is SACountry selectedCountry)
        {
            // Navegar a la p�gina de detalles pasando el nombre del pa�s como par�metro
            await Shell.Current.GoToAsync($"///countrydetails?name={selectedCountry.Name.Common}");
        }

        // Deseleccionar el item despu�s de la navegaci�n
        ((ListView)sender).SelectedItem = null;
    }
}