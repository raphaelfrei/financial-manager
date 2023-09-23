namespace FiMa;

public partial class ForgotPasswordTwo : ContentPage
{
	public ForgotPasswordTwo()
	{
		InitializeComponent();
	}

    private void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ForgotPasswordOne());
        Navigation.RemovePage(this);
    }

    private void BtnProximo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ForgotPasswordTree());
        Navigation.RemovePage(this);
    }
    void OnClickForgotPass(System.Object sender, System.EventArgs e)
    {
        ContentPage navTo = new ForgotPasswordOne();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }
}