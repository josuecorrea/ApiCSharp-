using Norm;
using Projeto.Api.Dominio.FormaPagamento;
using System;
using System.Collections.Generic;

namespace Projeto.Api.Dominio.Cliente
{
    public class ClienteModel
    {
        public ObjectId Id { get; set; }

        public string RazaSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJCPF { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Ie { get; set; }

        public string Im { get; set; }

        public string PathCertificado { get; set; }

        public DateTime ValidadeCertificado { get; set; }

        public string Responsavel { get; set; }

        public string Uf { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string RamoAtividade { get; set; }

        public string Cnae { get; set; }

        public bool Matriz { get; set; }

        public DateTime? UltimaCompra { get; set; }

        public DateTime? DataNascimento { get; set; }

        public decimal LimiteCredito { get; set; }

        public List<FormaPagamentoModel> FormasDePagamentoQueOhClientePodeUtilizar { get; set; }
    }
}