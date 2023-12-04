using System;

namespace FiMa.Models {

    public class InAndOut {

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }

        public InAndOut(string nome, decimal valor, string imagem) {
            Nome = nome;
            Valor = valor;
            Imagem = imagem;
        }

    }
}

