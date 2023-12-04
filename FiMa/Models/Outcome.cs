using System;

namespace FiMa.Models {
    public class Outcome {

        public int IDDespesa { get; set; }
        public decimal ValorDespesa { get; set; }
        public string DescricaoDespesa { get; set; }
        public string CategoriaDespesa { get; set; }
        public string DataDespesa { get; set; }
        public string FormaPagamentoDespesa { get; set; }
        public int ParcelamentoDespesa { get; set; }
        public int IDUsuario { get; set; }
        public string ImageSource { get; set; }

        public Outcome(int idDespesa, string valorDespesa, string descricaoDespesa, string categoriaDespesa, string dataDespesa, string formaPagamentoDespesa, int parcelamentoDespesa, int idUsuario, string imageSource) {
            IDDespesa = idDespesa;
            ValorDespesa = Convert.ToDecimal(valorDespesa);
            DescricaoDespesa = descricaoDespesa;
            CategoriaDespesa = categoriaDespesa;
            DataDespesa = dataDespesa;
            FormaPagamentoDespesa = formaPagamentoDespesa;
            ParcelamentoDespesa = parcelamentoDespesa;
            IDUsuario = idUsuario;
            ImageSource = imageSource;
        }

    }
}

