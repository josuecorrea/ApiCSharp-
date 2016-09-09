using Norm;
using System;

namespace Projeto.Api.Dominio.Empresa
{
    public class EmpresaModel
    {
        public ObjectId Id { get; set; }

        public string RazaSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Ie { get; set; }

        public string Im { get; set; }

        public string PathCertificado { get; set; }

        public DateTime ValidadeCertificado { get; set; }

        public string Uf { get; set; }

        public string Responsavel { get; set; }

        public bool NFe { get; set; }

        public bool CTe { get; set; }

        public bool NFse { get; set; }

        public bool NFce { get; set; }

        public bool CFeSat { get; set; }

        public string Contador { get; set; }

        public bool PeriodoDeTeste { get; set; }
       
        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string RamoAtividade { get; set; }

        public string Cnae { get; set; }
        
        public bool Matriz { get; set; }        
    }
}