namespace FiMa;

public partial class ForgotPasswordTree : ContentPage
{
	public ForgotPasswordTree()
	{
		InitializeComponent();
	}

    private void BtnConcluir_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ForgotPasswordConcluido());
        Navigation.RemovePage(this);
    }
}