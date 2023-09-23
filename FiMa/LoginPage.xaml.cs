namespace FiMa;

public partial class LoginPage : ContentPage {

    public LoginPage() {
        InitializeComponent();
    }

    void BtnEntrar_Clicked(System.Object sender, System.EventArgs e) {

    }

    void BtnCadastrar_Clicked(System.Object sender, System.EventArgs e) {
        ContentPage navTo = new CreateAccountOne();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }

    void OnClickForgotPass(System.Object sender, System.EventArgs e) {
        ContentPage navTo = new ForgotPasswordOne();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }
}
