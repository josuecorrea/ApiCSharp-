using Norm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Api.Dominio.Usuario
{
    public class UsuarioModel
    {
        public ObjectId Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Senha deve conter 6 caracters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracters e no minimo 6.", MinimumLength = 6)]
        public string Nome { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "CNPJ deve conter 14 caracters", MinimumLength = 14)]
        public string CpfCnpj { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "Celular deve conter 11 caracters", MinimumLength = 11)]
        public string Celular { get; set; }

        [StringLength(11, ErrorMessage = "Telefone fixo deve conter 11 caracters", MinimumLength = 11)]
        public string Fixo { get; set; }

        public bool Ativo { get; set; } = true;

        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public bool Master { get; set; } = false;

        [Required]
        public int LimiteEmpresas { get; set; }

        public List<UsuarioEmpresaModel> MinhasEmpresas { get; set; }

        public bool Tenant { get; set; } = false;

        [Required]
        public string TipoUsuario { get; set; }
    }
}