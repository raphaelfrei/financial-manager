namespace FiMa;

public partial class CreateAccountTree : ContentPage {

    public CreateAccountTree() {
        InitializeComponent();
    }

    private void BtnConcluir_Clicked(object sender, EventArgs e) {

        if (!HasCorrectLength(EtSenha.Text)) {
            DisplayAlert("Erro", "O tamanho da senha está fora do requerido.", "OK");
            return;
        }

        if (!HasNumericChar(EtSenha.Text)) {
            DisplayAlert("Erro", "A senha necessita possuir pelo menos 1 número.", "OK");
            return;
        }

        if (!HasUpercaseChar(EtSenha.Text)) {
            DisplayAlert("Erro", "A senha necessita pelo menos 1 caracter maíusculo.", "OK");
            return;
        }

        if (!HasLowercaseChar(EtSenha.Text)) {
            DisplayAlert("Erro", "A senha necessita pelo menos 1 caracter minúsculo.", "OK");
            return;

        }

        if (!AreEqual(EtSenha.Text, EtSenhaRepete.Text)) {
            DisplayAlert("Erro", "As senhas não coincidem.", "OK");
            return;
        }

        Navigation.PushAsync(new CreateAccountConcluido());
        Navigation.RemovePage(this);
    }

    void PasswordEntry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e) {

        if (!HasCorrectLength(EtSenha.Text))
            LbMinimoChar.TextColor = Colors.PaleVioletRed;
        else
            LbMinimoChar.TextColor = Colors.Black;

        if (!HasNumericChar(EtSenha.Text))
            LbMinimoNumero.TextColor = Colors.PaleVioletRed;
        else
            LbMinimoNumero.TextColor = Colors.Black;

        if (!HasUpercaseChar(EtSenha.Text))
            LbMinimoMaiusculo.TextColor = Colors.PaleVioletRed;
        else
            LbMinimoMaiusculo.TextColor = Colors.Black;

        if (!HasLowercaseChar(EtSenha.Text))
            LbMinimoMinusculo.TextColor = Colors.PaleVioletRed;
        else
            LbMinimoMinusculo.TextColor = Colors.Black;

        if (!AreEqual(EtSenha.Text, EtSenhaRepete.Text))
            LbCoincide.TextColor = Colors.PaleVioletRed;
        else
            LbCoincide.TextColor = Colors.Black;

    }

    void EtSenhaRepete_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e) {
        if (!AreEqual(EtSenha.Text, EtSenhaRepete.Text))
            LbCoincide.TextColor = Colors.PaleVioletRed;
        else
            LbCoincide.TextColor = Colors.Black;
    }

    bool HasCorrectLength(string text) {
        return (text.Length >= 8 && text.Length <= 20);
    }

    bool HasNumericChar(string text) {
        return text.Any(char.IsDigit);
    }

    bool HasUpercaseChar(string text) {
        return text.Any(char.IsUpper);
    }

    bool HasLowercaseChar(string text) {
        return text.Any(char.IsLower);
    }

    bool AreEqual(string text, string compare) {
        return text == compare;
    }
}