using System;

namespace FiMa.Models {
    public class User {

        public int IDUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string DataNascimento { get; set; }
        public string GeneroUsuario { get; set; }
        public int VaiInvestir { get; set; }
        public int VaiQuitarDivida { get; set; }
        public int VaiControlarGastos { get; set; }
        public int VaiPlanejar { get; set; }
        public int RendaMensal { get; set; }
        public int DespesaFixa { get; set; }
        public string SenhaUsuario { get; set; }

    }
}

