namespace FiMa;

public partial class PaginaDespesas : ContentPage
{
	public PaginaDespesas()
	{
		InitializeComponent();
	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);
    }

    private void BtnConfirmar_Clicked(object sender, EventArgs e)
    {
        ContentPage navTo = new PaginaDespesaConcluido();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }
}