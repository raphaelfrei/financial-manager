namespace FiMa;

public partial class AdicionarReceita : ContentPage {
    public AdicionarReceita() {
        InitializeComponent();
    }

    private void BtnConcluir_Clicked(object sender, EventArgs e) {

        if (EtDesc.Text == "")
            EtDesc.Text = "Receita";

        ContentPage navTo = new PaginaReceitaConcluida();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }

    private void BtnCancelar_Clicked(object sender, EventArgs e) {
        //.PushAsync(new MainPage());
        Navigation.PopAsync();
    }
}