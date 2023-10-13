namespace FiMa;

public partial class ForgotPasswordConcluido : ContentPage
{
	public ForgotPasswordConcluido()
	{
		InitializeComponent();
	}

    private void BtnConcluir_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
        Navigation.RemovePage(this);
    }
}