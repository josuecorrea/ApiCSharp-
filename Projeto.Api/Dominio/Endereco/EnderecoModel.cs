using Norm;

namespace Projeto.Api.Dominio.Endereco
{
    public class EnderecoModel
    {
        public ObjectId Id { get; set; }

        public string EmpresaClientId { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }

        public string Municipio { get; set; }

        public string CodigoMunicipio { get; set; }

        public string Referencia { get; set; }

        public string Cep { get; set; }
    }
}