namespace FiMa;

public partial class CreateAccountTree : ContentPage
{
	public CreateAccountTree()
	{
		InitializeComponent();
	}

    private void BtnConcluir_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateAccountConcluido());
        Navigation.RemovePage(this);
    }
}