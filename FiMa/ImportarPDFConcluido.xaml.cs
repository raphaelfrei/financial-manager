namespace FiMa;

public partial class ImportarPDFConcluido : ContentPage {
    public ImportarPDFConcluido() {
        InitializeComponent();
    }

    private void BtnEntrar_Clicked(object sender, EventArgs e) {
        //Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);
    }
}