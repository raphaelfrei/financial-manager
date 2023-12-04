using System.Text.RegularExpressions;
using FiMa.Models;

namespace FiMa;

public partial class PaginaDespesas : ContentPage {
    public PaginaDespesas() {
        InitializeComponent();

        this.Disappearing += OnDisappearingHandler;
    }

    private void BtnVoltar_Clicked(object sender, EventArgs e) {
        //Navigation.PushAsync(new MainPage());
        Navigation.PopAsync();
    }

    private void BtnConfirmar_Clicked(object sender, EventArgs e) {

        if (EtDesc.Text == "")
            EtDesc.Text = "Despesa";

        if (string.IsNullOrWhiteSpace(EtDespesa.Text) || EtDespesa.Text == "") {
            DisplayAlert("Erro", "O valor da despesa não pode ser 0.", "OK");
            return;
        }

        if (PcGenero.SelectedIndex == -1) {
            DisplayAlert("Erro", "Selecione uma categoria da despesa.", "OK");
            return;
        }

        int parcelamento = 1;

        if (PckForma.SelectedIndex == 3)
            parcelamento = Convert.ToInt32(EtParcela.Text);
        else if (PckForma.SelectedIndex == -1) {
            DisplayAlert("Erro", "Selecione uma forma de pagamento.", "OK");
            return;
        }

        if (parcelamento == 1 && PckForma.SelectedIndex == 3) {
            DisplayAlert("Erro", "Para compras parceladas, selecione no mínimo 2 meses de parcelamento.", "OK");
            return;
        }

        string arquivoImagem = string.Empty;

        switch (PcGenero.SelectedIndex) {
            case -1:
                DisplayAlert("Erro", "Selecione uma categoria para a sua despesa.", "OK");
                return;

            case 0:
                arquivoImagem = "restaurante_icone.png";
                break;

            case 1:
                arquivoImagem = "mercado_icone.png";
                break;

            case 2:
                arquivoImagem = "conta_icone.png";
                break;

            case 3:
                arquivoImagem = "lazer_icone.png";
                break;

            case 4:
                arquivoImagem = "medico_icone.png";
                break;

            case 5:
                arquivoImagem = "outros_icone.png";
                break;
        }

        SQLConn.CreateOutcome(new Outcome(0, EtDespesa.Text, EtDesc.Text, PcGenero.SelectedItem.ToString(), $"{DpNascimento.Date.Year:0000}-{DpNascimento.Date.Month:00}-{DpNascimento.Date.Day:00}", PckForma.SelectedItem.ToString(), parcelamento, SQLConn.IDUsuario, arquivoImagem));

        //DisplayAlert("Sair?", SQLConn.CreateOutcome(new Outcome(0, EtDespesa.Text, EtDesc.Text, PcGenero.SelectedItem.ToString(), DpNascimento.Date.ToString(), PckForma.SelectedItem.ToString(), parcelamento, SQLConn.IDUsuario, arquivoImagem)), "Sair?");

        ContentPage navTo = new PaginaDespesaConcluido();
        Navigation.PushAsync(navTo);
        Navigation.RemovePage(this);
    }

    private async void OnDisappearingHandler(object sender, EventArgs e) {
        //if (HasModified) {

        //    var leave = await DisplayAlert("Sair?", "Você possui alterações não salvas. Deseja sair?", "Sim", "Não");

        //    if (!leave)
        //        return;
        //}


        MessagingCenter.Send(this, "PaginaFechada");
        this.Disappearing -= OnDisappearingHandler;
    }

    void EtDespesa_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e) {

        EtDespesa.Text = Regex.Replace(EtDespesa.Text, "[^0-9],", "");

        if (e.NewTextValue.Contains(',')) {
            if (e.NewTextValue.Length - 1 - e.NewTextValue.IndexOf(",") > 2) {
                var s = e.NewTextValue[..(e.NewTextValue.IndexOf(",") + 2 + 1)];
                EtDespesa.Text = s;
                EtDespesa.SelectionLength = s.Length;
            }
        }

    }

    void PckForma_SelectedIndexChanged(System.Object sender, System.EventArgs e) {

        if (PckForma.SelectedIndex == 3) {
            LbParcela.IsVisible = true;
            EtParcela.IsVisible = true;
        } else {
            EtParcela.Text = "1";
            LbParcela.IsVisible = false;
            EtParcela.IsVisible = false;
        }

    }

    void EtParcela_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e) {
        EtParcela.Text = Regex.Replace(EtParcela.Text, "[^0-9,]", "");
    }
}