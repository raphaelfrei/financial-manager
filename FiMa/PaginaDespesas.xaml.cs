namespace FiMa;

public partial class PaginaDespesas : ContentPage {
    public PaginaDespesas() {
        InitializeComponent();
    }

    private void BtnVoltar_Clicked(object sender, EventArgs e) {
        //Navigation.PushAsync(new MainPage());
        Navigation.PopAsync();
    }

    private void BtnConfirmar_Clicked(object sender, EventArgs e) {
        if (EtDesc.Text == "")
            EtDesc.Text = "Despesa";

        ContentPage navTo = new PaginaDespesaConcluido();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }
}