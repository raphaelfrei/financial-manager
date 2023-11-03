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

    }
}

