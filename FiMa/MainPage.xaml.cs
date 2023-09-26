﻿namespace FiMa;

public partial class MainPage : TabbedPage {
    public MainPage() {
        InitializeComponent();
    }

    private void BtnCadastrar_Clicked(object sender, EventArgs e)
    {
        ContentPage navTo = new AdicionarReceita();
        Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);
    }

    private void BtnDespesas_Clicked(object sender, EventArgs e)
    {
        ContentPage navTo = new PaginaDespesas();
        Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);
    }

    private void BtnPDF_Clicked(object sender, EventArgs e)
    {
        ContentPage navTo = new ImportarPDF();
        Navigation.PushAsync(navTo);
        //Navigation.RemovePage(this);
    }
}
