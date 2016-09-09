using Norm;
using System;

namespace Projeto.Api.Dominio.Fornecedor
{
    public class FornecedorModel
    {
        public ObjectId Id { get; set; }

        public string RazaSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Ie { get; set; }

        public string Im { get; set; }

        public string Uf { get; set; }

        public string Responsavel { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string RamoAtividade { get; set; }

        public DateTime? UltimaCompra { get; set; }
    }
}