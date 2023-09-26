namespace FiMa;

public partial class CreateAccountTwo : ContentPage {

    public CreateAccountTwo() {
        InitializeComponent();
    }

    void BtnProximo_Clicked(System.Object sender, System.EventArgs e) {

        if (!CBInvestir.IsChecked && !CBDivida.IsChecked && !CBControlar.IsChecked && !CBPlanejar.IsChecked) {
            DisplayAlert("Erro", "Você deve selecionar ao menos um objetivo.", "OK");
            return;
        }

        if (String.IsNullOrWhiteSpace(EtRenda.Text) || Convert.ToInt32(EtRenda.Text) == 0) {
            DisplayAlert("Erro", "Sua renda deve ser maior que R$ 0.", "OK");
            return;
        }

        if (String.IsNullOrWhiteSpace(EtDespesa.Text) || Convert.ToInt32(EtDespesa.Text) == 0) {
            DisplayAlert("Erro", "Sua despesa deve ser maior que R$ 0.", "OK");
            return;
        }

        Navigation.PushAsync(new CreateAccountTree());
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
