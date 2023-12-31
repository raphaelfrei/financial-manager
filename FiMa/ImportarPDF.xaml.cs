using static System.Net.Mime.MediaTypeNames;

namespace FiMa;

public partial class ImportarPDF : ContentPage {

    bool isCodeChangingCheckState = false;

    public ImportarPDF() {
        InitializeComponent();
    }

    private void BtnEntrar_Clicked(object sender, EventArgs e) {
        Navigation.PushAsync(new ImportarPDFConcluido());
        Navigation.RemovePage(this);
    }

    private void BtnVoltar_Clicked(object sender, EventArgs e) {
        //Navigation.PushAsync(new MainPage());
        Navigation.PopAsync();
    }

    void CbSenha_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e) {

        if (!CbSenha.IsChecked) {
            EtSenha.IsEnabled = false;
            EtSenha.Text = "";
        } else
            EtSenha.IsEnabled = true;
    }

    async void BtnProcurar_Clicked(System.Object sender, System.EventArgs e) {
        var options = new PickOptions {
            PickerTitle = "Por favor, selecione um arquivo PDF",
            FileTypes = FilePickerFileType.Pdf,
        };
        var file = await PickAndShow(options);
    }

    async Task<FileResult> PickAndShow(PickOptions options) {
        try {
            var result = await FilePicker.PickAsync(options);
            if (result != null) {
                //Text = $"Arquivo selecionado: {result.FileName}";
                if (result.FileName.EndsWith("pdf", StringComparison.OrdinalIgnoreCase)) {
                    //var stream = await result.OpenReadAsync();
                    // Aqui você pode usar o stream para abrir o arquivo PDF
                }
            }
            return result;
        } catch (Exception) {
            // O usuário cancelou ou algo deu errado
        }
        return null;
    }
}