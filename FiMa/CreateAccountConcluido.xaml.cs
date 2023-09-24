namespace FiMa;

public partial class CreateAccountConcluido : ContentPage {
    public CreateAccountConcluido() {
        InitializeComponent();
    }

    private void BtnConcluir_Clicked(object sender, EventArgs e) {
        Navigation.PushAsync(new LoginPage());
        Navigation.RemovePage(this);
    }
}