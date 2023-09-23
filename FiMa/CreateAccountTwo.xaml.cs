namespace FiMa;

public partial class CreateAccountTwo : ContentPage {
    public CreateAccountTwo() {
        InitializeComponent();
    }

    void BtnProximo_Clicked(System.Object sender, System.EventArgs e) {
        Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);
    }

    void OnClickInvestir(object sender, EventArgs args) {
        CBInvestir.IsChecked = !CBInvestir.IsChecked;
    }

    void OnClickDivida(object sender, EventArgs args) {
        CBDivida.IsChecked = !CBDivida.IsChecked;
    }

    void OnClickControlar(object sender, EventArgs args) {
        CBControlar.IsChecked = !CBControlar.IsChecked;
    }

    void OnClickPlanejar(object sender, EventArgs args) {
        CBPlanejar.IsChecked = !CBPlanejar.IsChecked;
    }
}
