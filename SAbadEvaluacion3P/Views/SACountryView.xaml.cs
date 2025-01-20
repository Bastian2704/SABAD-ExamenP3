namespace SAbadEvaluacion3P.Views;
using SAbadEvaluacion3P.ModelViews;

public partial class SACountryView : ContentPage
{
	public SACountryView()
	{
		InitializeComponent();
        BindingContext = new SACountryModelView();
    }
}