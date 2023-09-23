namespace FiMa;

public partial class ImportarPDF : ContentPage
{
	public ImportarPDF()
	{
		InitializeComponent();
	}

    private void BtnEntrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ImportarPDFConcluido());
        Navigation.RemovePage(this);
    }

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);
    }

    void OnClickSim(object sender, EventArgs args)
    {
        CBInvestir.IsChecked = !CBInvestir.IsChecked;
    }

    void OnClickNao(object sender, EventArgs args)
    {
        CBControlar.IsChecked = !CBControlar.IsChecked;
    }
}