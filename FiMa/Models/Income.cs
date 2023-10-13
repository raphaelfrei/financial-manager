using System;

namespace FiMa.Models {

    public class Income {

        public int IDReceita { get; set; }
        public decimal ValorReceita { get; set; }
        public string DescricaoReceita { get; set; }
        public string ComentarioReceita { get; set; }
        public int IDUsuario { get; set; }

    }
}

