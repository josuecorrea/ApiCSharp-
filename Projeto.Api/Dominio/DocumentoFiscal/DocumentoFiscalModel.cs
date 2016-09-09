using Norm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Api.Dominio.DocumentoFiscal
{
    public class DocumentoFiscalModel
    {
        public ObjectId Id { get; set; }

        public int Numero { get; set; }

        public DateTime DataEmissao { get; set; }

        public decimal Valor { get; set; }

        public string Cancelada { get; set; }

        public string Cnpj { get; set; }

        public string EntradaSaida { get; set; }

        public string XML { get; set; }

        public string Emitente { get; set; }

        public string Destinatario { get; set; }

        public string PathPdf { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public string Tipo { get; set; }

        public DateTime DataCadastroSistema { get; set; }
    }
}