namespace FiMa;

public partial class ForgotPasswordOne : ContentPage {

    public ForgotPasswordOne() {
        InitializeComponent();
    }

    void BtnProximo_Clicked(System.Object sender, System.EventArgs e) {

    }

    void BtnVoltar_Clicked(System.Object sender, System.EventArgs e) {
        Navigation.PushAsync(new LoginPage());
        Navigation.RemovePage(this);
    }
}
