using System.Collections.ObjectModel;
using FiMa.Models;

namespace FiMa;

public partial class MainPage : TabbedPage {

    public ObservableCollection<Outcome> DespesasCollection { get; set; }

    public MainPage() {
        InitializeComponent();
        DespesasCollection = new ObservableCollection<Outcome>();
        BindingContext = this;
        CreateTestInfoDesp();

    }

    private void CreateTestInfoDesp() {
        Outcome teste = new Outcome();

        teste.DataDespesa = DateTime.Today.ToShortDateString();
        teste.DescricaoDespesa = "Outback";
        teste.ValorDespesa = 99.90m;
        teste.ImageSource = "restaurante_icone.png";
        DisplayAlert("ABC", $"{teste.DataDespesa} - {teste.DescricaoDespesa} - {teste.ValorDespesa}", "OK");
        //AddItem(teste);
    }

    private void AddItem(Outcome item) {

        DespesasCollection ??= new ObservableCollection<Outcome>();

        DespesasCollection.Add(item);

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
        ContentPage navTo = new ImportarPDF();
        Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) {
        DisplayAlert("ABC", "OK", "OK");
    }

    void BtnReceitasTeste_Clicked(System.Object sender, System.EventArgs e) {


    }

    void BtnDespTeste_Clicked(System.Object sender, System.EventArgs e) {
        CreateTestInfoDesp();

    }
}
