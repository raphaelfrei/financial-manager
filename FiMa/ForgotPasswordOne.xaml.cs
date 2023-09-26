namespace FiMa;

public partial class ForgotPasswordOne : ContentPage {

    public ForgotPasswordOne() {
        InitializeComponent();
    }

    void BtnProximo_Clicked(System.Object sender, System.EventArgs e) {

        if (!VerifyEmail(EtEmail.Text))
            return;

        Navigation.PushAsync(new ForgotPasswordTwo(EtEmail.Text));
        Navigation.RemovePage(this);
    }

    void BtnVoltar_Clicked(System.Object sender, System.EventArgs e) {
        Navigation.PushAsync(new LoginPage());
        Navigation.RemovePage(this);
    }

    bool VerifyEmail(string email) {

        if (String.IsNullOrWhiteSpace(email)) {
            DisplayAlert("Erro", "O email é obrigatório!", "OK");
            return false;
        }

        if (!email.Contains('@') || !email.Contains('.')) {
            DisplayAlert("Erro", "O email informado não é valido!", "OK");
            return false;
        }

        return true;
    }
}
