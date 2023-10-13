using FiMa.Models;

namespace FiMa;

public partial class LoginPage : ContentPage {

    public LoginPage() {
        InitializeComponent();
    }

    void BtnEntrar_Clicked(System.Object sender, System.EventArgs e) {

        int status = SQLConn.TryLogin(EtEmail.Text, EtSenha.Text);

        if (status == 0) {
            DisplayAlert("Erro", "Um erro aconteceu. Tente novamente mais tarde.", "OK");
        } else if (status == 1) {
            Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);

        } else if (status == 2) {
            DisplayAlert("Erro", "O email informado não está cadastrado no sistema. Verifique e tente novamente.", "OK");
            EtEmail.Text = string.Empty;
            EtSenha.Text = string.Empty;
        } else {
            DisplayAlert("Erro", "A senha informada está incorreta. Verifique e tente novamente.", "OK");
            EtSenha.Text = string.Empty;
        }


    }

    void BtnCadastrar_Clicked(System.Object sender, System.EventArgs e) {
        //ContentPage navTo = new CreateAccountOne();
        //Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);

        User user = new User();
        user.NomeUsuario = "Raphael Frei";
        user.EmailUsuario = "raphaelrfrei@gmail.com";
        user.DespesaFixa = 1000;
        user.RendaMensal = 5000;
        user.DataNascimento = "14/02/2002";
        user.GeneroUsuario = "1";
        user.VaiControlarGastos = 1;
        user.VaiInvestir = 1;
        user.VaiPlanejar = 1;
        user.VaiQuitarDivida = 0;
        user.SenhaUsuario = ConvertToMD5.ConvertStringToMD5("1");
        //SQLConn.AddUser(user);
        var result = SQLConn.AddUser(user);

        if (result.Item1)
            DisplayAlert("Sucesso", "A conta foi criada com sucesso, retorne ao Menu Principal para acessá-la.", "OK");
        else
            DisplayAlert("Erro", $"Um erro aconteceu. Tente novamente mais tarde.\n{result.Item2}", "OK");
    }

    void OnClickForgotPass(System.Object sender, System.EventArgs e) {
        ContentPage navTo = new ForgotPasswordOne();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }
}
