using System.Text.RegularExpressions;
using FiMa.Models;

namespace FiMa;

public partial class AdicionarReceita : ContentPage {

    public AdicionarReceita() {
        InitializeComponent();
        this.Disappearing += OnDisappearingHandler;
    }

    private void BtnConcluir_Clicked(object sender, EventArgs e) {

        if (EtDesc.Text == "")
            EtDesc.Text = "Receita";

        if (string.IsNullOrWhiteSpace(EtReceita.Text) || EtReceita.Text == "0") {
            DisplayAlert("Erro", "O valor da receita não pode ser 0.", "OK");
            return;
        }

        SQLConn.CreateIncome(new Income(0, EtReceita.Text, EtDesc.Text, string.Empty, SQLConn.IDUsuario, "saraio_icone.png", $"{DpNascimento.Date.Year:0000}-{DpNascimento.Date.Month:00}-{DpNascimento.Date.Day:00}"));

        ContentPage navTo = new PaginaReceitaConcluida();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }

    private void BtnCancelar_Clicked(object sender, EventArgs e) {
        //.PushAsync(new MainPage());
        Navigation.PopAsync();
    }

    private void OnDisappearingHandler(object sender, EventArgs e) {
        //if (HasModified) {

        //    var leave = await DisplayAlert("Sair?", "Você possui alterações não salvas. Deseja sair?", "Sim", "Não");

        //    if (!leave)
        //        return;
        //}


        MessagingCenter.Send(this, "PaginaFechada");
        this.Disappearing -= OnDisappearingHandler;
    }

    void EtReceita_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e) {
        EtReceita.Text = Regex.Replace(EtReceita.Text, "[^0-9],", "");

        if (e.NewTextValue.Contains(',')) {
            if (e.NewTextValue.Length - 1 - e.NewTextValue.IndexOf(",") > 2) {
                var s = e.NewTextValue[..(e.NewTextValue.IndexOf(",") + 2 + 1)];
                EtReceita.Text = s;
                EtReceita.SelectionLength = s.Length;
            }
        }
    }
}