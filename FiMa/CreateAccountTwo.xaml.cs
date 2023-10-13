using FiMa.Models;

namespace FiMa;

public partial class CreateAccountTwo : ContentPage {

    private User Usuario;

    public CreateAccountTwo(User usuario) {
        InitializeComponent();

        Usuario = usuario;
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

        Usuario.RendaMensal = Convert.ToInt32(EtRenda.Text);
        Usuario.DespesaFixa = Convert.ToInt32(EtDespesa.Text);

        if (CBInvestir.IsChecked)
            Usuario.VaiInvestir = 1;
        else
            Usuario.VaiInvestir = 0;

        if (CBDivida.IsChecked)
            Usuario.VaiQuitarDivida = 1;
        else
            Usuario.VaiQuitarDivida = 0;

        if (CBControlar.IsChecked)
            Usuario.VaiControlarGastos = 1;
        else
            Usuario.VaiControlarGastos = 0;

        if (CBPlanejar.IsChecked)
            Usuario.VaiPlanejar = 1;
        else
            Usuario.VaiPlanejar = 0;

        Navigation.PushAsync(new CreateAccountTree(Usuario));
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
