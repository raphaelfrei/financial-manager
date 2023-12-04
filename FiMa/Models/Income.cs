using System;

namespace FiMa.Models {

    public class Income {

        public int IDReceita { get; set; }
        public decimal ValorReceita { get; set; }
        public string DescricaoReceita { get; set; }
        public string ComentarioReceita { get; set; }
        public int IDUsuario { get; set; }
        public string ImageSource { get; set; }
        public string DataReceita { get; set; }

        public Income(int idReceita, string valorReceita, string descricaoReceita, string comentarioReceita, int idUsuario, string imageSource, string dataReceita) {
            IDReceita = idReceita;
            ValorReceita = Convert.ToDecimal(valorReceita);
            DescricaoReceita = descricaoReceita;
            ComentarioReceita = comentarioReceita;
            IDUsuario = idUsuario;
            ImageSource = "saraio_icone.png";
            DataReceita = dataReceita;
        }

    }
}

