using System.Collections.ObjectModel;
using FiMa.Models;
using Microsoft.VisualBasic;

namespace FiMa;

public partial class MainPage : TabbedPage {

    public ObservableCollection<Outcome> DespesasCollection { get; set; }

    public ObservableCollection<Income> ReceitasCollection { get; set; }

    public ObservableCollection<InAndOut> AllCollection { get; set; }

    public MainPage() {
        InitializeComponent();
        DespesasCollection = new ObservableCollection<Outcome>();
        ReceitasCollection = new ObservableCollection<Income>();
        AllCollection = new ObservableCollection<InAndOut>();
        BindingContext = this;
        //DisplayAlert("Aviso", $"Você está rodando uma versão beta do aplicativo. Por conta disso, alguns dados já foram preenchidos.", "OK");
    }

    private void UpdateData() {

        ReceitasCollection.Clear();
        DespesasCollection.Clear();
        AllCollection.Clear();

        List<Income> temp = SQLConn.GetIncomes();

        foreach (Income item in temp) {
            AddItem(new InAndOut(item.DescricaoReceita, item.ValorReceita, item.ImageSource));
            AddItem(item);
        }

        List<Outcome> temp2 = SQLConn.GetOutcomes();

        foreach (Outcome item in temp2) {
            AddItem(new InAndOut(item.DescricaoDespesa, (item.ValorDespesa * -1), item.ImageSource));
            AddItem(item);
        }

        decimal receitaTotal = SQLConn.GetMonthlyTotalIncome(DateTime.Now.Month, DateTime.Now.Year).value;
        decimal despesaTotal = SQLConn.GetMonthlyTotalOutcome(DateTime.Now.Month, DateTime.Now.Year);

        LbReceita.Text = $"R$ {Convert.ToDouble(receitaTotal):N2}";
        LbReceitaCifra.Text = $"R$ {Convert.ToDouble(receitaTotal):N2}";
        LbRenda.Text = $"R$ {Convert.ToDouble(receitaTotal):N2}";

        LbDespesa.Text = $"R$ {Convert.ToDouble(despesaTotal):N2}";
        LbDespesaCifra.Text = $"R$ {Convert.ToDouble(despesaTotal):N2}";
        LbDesp.Text = $"R$ {Convert.ToDouble(despesaTotal):N2}";

        LbTotalMoney.Text = $"R$ {(Convert.ToDouble(receitaTotal) - Convert.ToDouble(despesaTotal)):N2}";

        /* Slider do menu HOME */

        decimal div1 = receitaTotal;
        if (div1 < 1)
            div1 = 1;

        decimal div2 = despesaTotal;
        if (div2 < 1)
            div2 = 1;

        SldExtratoHome.Value = 100 - (Convert.ToDouble((div2 / div1) * 100));

        LbPorcentoRenda.Text = $"Você comprometeu {Convert.ToInt32((div2 / div1) * 100)}% da sua renda";

        if (SldExtratoHome.Value >= 99)
            SldExtratoHome.MaximumTrackColor = Colors.Green;
        else
            SldExtratoHome.MaximumTrackColor = Colors.Red;

        if (SldExtratoHome.Value <= 1)
            SldExtratoHome.MinimumTrackColor = Colors.Red;
        else
            SldExtratoHome.MinimumTrackColor = Colors.Green;

        /* Slider do menu RECEITA */

        decimal metaRenda = 15000m;

        SldMetaRenda.Value = (Convert.ToDouble((div1 / metaRenda) * 100));

        if (SldMetaRenda.Value >= 99)
            SldMetaRenda.MaximumTrackColor = Colors.Green;
        else
            SldMetaRenda.MaximumTrackColor = Colors.Red;

        if (SldMetaRenda.Value <= 1)
            SldMetaRenda.MinimumTrackColor = Colors.Red;
        else
            SldMetaRenda.MinimumTrackColor = Colors.Green;

        /* Slider do menu DESPESA */

        decimal metaDespesa = 8300m;

        SldMetaDespesa.Value = (Convert.ToDouble((div2 / metaDespesa) * 100));

        if (SldMetaDespesa.Value >= 99)
            SldMetaDespesa.MaximumTrackColor = Colors.Red;
        else
            SldMetaDespesa.MaximumTrackColor = Colors.Green;

        if (SldMetaDespesa.Value <= 1)
            SldMetaDespesa.MinimumTrackColor = Colors.Green;
        else
            SldMetaDespesa.MinimumTrackColor = Colors.Red;

    }

    private void AddItem(Outcome item) {

        DespesasCollection ??= new ObservableCollection<Outcome>();

        DespesasCollection.Add(item);

    }

    private void AddItem(Income item) {

        ReceitasCollection ??= new ObservableCollection<Income>();

        ReceitasCollection.Add(item);

    }

    private void AddItem(InAndOut item) {

        AllCollection ??= new ObservableCollection<InAndOut>();

        AllCollection.Add(item);

    }

    async void AddDespesa_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) {
        ContentPage navTo = new PaginaDespesas();

        // Inscreva-se para a mensagem
        MessagingCenter.Subscribe<PaginaDespesas>(this, "PaginaFechada", (sender) => {
            // Este código será executado quando a mensagem for recebida
            UpdateData();
        });

        await Navigation.PushAsync(navTo);
    }

    //TapGestureRecognizer_Tapped
    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) {
        DisplayAlert("Aviso", $"O aplicativo se encontra atualmente em fase de prototipação, por conta disso, esse recurso não está disponível.", "OK");
    }

    async void AddReceita_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) {
        ContentPage navTo = new AdicionarReceita();

        // Inscreva-se para a mensagem
        MessagingCenter.Subscribe<AdicionarReceita>(this, "PaginaFechada", (sender) => {
            // Este código será executado quando a mensagem for recebida
            UpdateData();
        });

        await Navigation.PushAsync(navTo);

    }

    async void ImportarFatura_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e) {
        ContentPage navTo = new ImportarPDF();

        // Inscreva-se para a mensagem
        MessagingCenter.Subscribe<ImportarPDF>(this, "PaginaFechada", (sender) => {
            // Este código será executado quando a mensagem for recebida
            UpdateData();
        });

        await Navigation.PushAsync(navTo);
    }
}
