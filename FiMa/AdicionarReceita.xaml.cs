namespace FiMa;

public partial class AdicionarReceita : ContentPage
{
	public AdicionarReceita()
	{
		InitializeComponent();
	}

    private void BtnConcluir_Clicked(object sender, EventArgs e)
    {
        ContentPage navTo = new PaginaReceitaConcluida();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }

    private void BtnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);
    }
}