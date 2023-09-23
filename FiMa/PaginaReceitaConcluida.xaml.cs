namespace FiMa;

public partial class PaginaReceitaConcluida : ContentPage
{
	public PaginaReceitaConcluida()
	{
		InitializeComponent();
	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);
    }
}