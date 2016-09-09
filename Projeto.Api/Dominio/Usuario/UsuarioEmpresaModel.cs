using System;

namespace Projeto.Api.Dominio.Usuario
{
    public class UsuarioEmpresaModel
    {
        public string Cnpj { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}