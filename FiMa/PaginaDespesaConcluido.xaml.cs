namespace FiMa;

public partial class PaginaDespesaConcluido : ContentPage {
    public PaginaDespesaConcluido() {
        InitializeComponent();
    }

    private void BtnEntrar_Clicked(object sender, EventArgs e) {
        //Navigation.PushAsync(new MainPage());
        Navigation.RemovePage(this);
    }
}