namespace FiMa;

public partial class MainPage : TabbedPage {
    public MainPage() {
        InitializeComponent();
    }

    private void BtnCadastrar_Clicked(object sender, EventArgs e) {
        ContentPage navTo = new AdicionarReceita();
        Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);
    }

    private void BtnDespesas_Clicked(object sender, EventArgs e) {
        ContentPage navTo = new PaginaDespesas();
        Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);
    }

    private void BtnPDF_Clicked(object sender, EventArgs e) {
        ContentPage navTo = new DetalhesReceita();
        Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) {
        DisplayAlert("ABC", "OK", "OK");
    }
}
