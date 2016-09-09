using Norm;
using System;

namespace Projeto.Api.Log
{
    public class LogModel
    {
        public ObjectId Id { get; set; }

        public Tipo Tipo { get; set; }

        public string Mensagem { get; set; }

        public DateTime Data { get; set; }

        public string Classe { get; set; }

        public string Metodo { get; set; }

        public string Controller { get; set; }

        public int Linha { get; set; }

        public int QtdeRegistrosRetornados { get; set; }
    }
}