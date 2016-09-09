using Norm;
using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Api.Dominio.Produto
{
    public class ProdutoModel
    {
        public ObjectId Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string NomeReduzido { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Codigo { get; set; }

        [Required]
        public string EmpresaId { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public bool MovimentaEstoque { get; set; }

        public bool Composto { get; set; }

        [Required]
        public string Unidade { get; set; }

        public decimal Peso { get; set; }

        public decimal EstoqueAtual { get; set; }

        public string Tipo { get; set; }//olhar no marketup

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public decimal Custo { get; set; }

        public bool AceitaSaldoNegativo { get; set; }

        public decimal EstoqueMinimo { get; set; }

        [Required]
        public string Ncm { get; set; }

        public string CodigoBarras { get; set; }

        public decimal Altura { get; set; }

        public decimal Largura { get; set; }

        public decimal Profundidade { get; set; }

        public string Imagem { get; set; }

        public DateTime? UltimaVenda { get; set; }

        public DateTime? UltimaEntrada { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public bool Ativo { get; set; }

        public int ProdVendidosQuantasVezes { get; set; }

        public bool DescontoVenda { get; set; }

        public int PorcentagemDescontoVenda { get; set; }

        public string ClasseId { get; set; }

        public string SubClasseId { get; set; }

        public string CategoriaId { get; set; }

        public string SubCategoriaId { get; set; }

        public bool UsaGrade { get; set; }

        public string Referencia { get; set; }

        public string ReferenciaAuxliar { get; set; }

        public string LocalEstoque { get; set; }

        public string LocalEstoqueAuxiliar { get; set; }
    }
}