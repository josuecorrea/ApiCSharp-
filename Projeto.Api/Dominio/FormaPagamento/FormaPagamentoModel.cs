using Norm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Api.Dominio.FormaPagamento
{
    public class FormaPagamentoModel
    {
        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public bool AceitaParcelamento { get; set; }

        public int? QtdeParcelas { get; set; }

        public bool EntradaObrigatoria { get; set; }

        public DateTime DataCadastro { get; set; }


    }
}