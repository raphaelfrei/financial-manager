namespace FiMa;

public partial class CreateAccountOne : ContentPage {
    public CreateAccountOne() {
        InitializeComponent();
    }

    void BtnProximo_Clicked(System.Object sender, System.EventArgs e) {

        Navigation.PushAsync(new CreateAccountTwo());
        Navigation.RemovePage(this);
    }
}
