namespace FiMa;

public partial class CreateAccountOne : ContentPage {

    private readonly int IdadeMinima = 18;

    public CreateAccountOne() {
        InitializeComponent();
    }

    void BtnProximo_Clicked(System.Object sender, System.EventArgs e) {

        if (!VerifyName(EtNome.Text))
            return;

        if (!VerifyEmail(EtEmail.Text))
            return;

        if (!VerifyNascimento(DpNascimento.Date))
            return;

        if (!VerifyGenero())
            return;

        Navigation.PushAsync(new CreateAccountTwo());
        Navigation.RemovePage(this);
    }

    bool VerifyName(string name) {

        if (String.IsNullOrWhiteSpace(name)) {
            DisplayAlert("Erro", "O nome é obrigatório!", "OK");
            return false;
        }

        return true;
    }

    bool VerifyEmail(string email) {

        if (String.IsNullOrWhiteSpace(email)) {
            DisplayAlert("Erro", "O email é obrigatório!", "OK");
            return false;
        }

        if (!email.Contains('@') || !email.Contains('.')) {
            DisplayAlert("Erro", "O email informado não é valido!", "OK");
            return false;
        }

        return true;

    }

    bool VerifyNascimento(DateTime dataNascimento) {

        int idade = DateTime.Now.Year - dataNascimento.Year;

        if (dataNascimento > DateTime.Now.AddYears(-idade))
            idade--;

        if (idade < IdadeMinima) {
            DisplayAlert("Erro", $"Você deve possuir mais de {IdadeMinima} anos para poder se cadastrar.", "OK");
            return false;
        }

        return true;
    }

    bool VerifyGenero() {

        if (PcGenero.SelectedIndex == -1) {
            DisplayAlert("Erro", "Você deve selecionar o seu gênero.", "OK");
            return false;
        }

        return true;

    }
}
