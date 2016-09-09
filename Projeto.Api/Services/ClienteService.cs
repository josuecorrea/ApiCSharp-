using Projeto.Api.Dominio.Cliente;
using Projeto.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Projeto.Api.Services
{
    public static class ClienteService
    {
        private static readonly MongoRepository repo = new MongoRepository();

        public static async Task<List<ClienteModel>> ListaDeClientesAsync()
        {
            return await Task.Run(() => repo.All<ClienteModel>().ToList());
        }      

        public static async Task<ClienteModel> ClientePorCNPJCPF(string CNPJCPF)
        {
            return await Task.Run(() => repo.List<ClienteModel>(c => c.CNPJCPF.Equals(CNPJCPF)).SingleOrDefault());
        }

        public static async Task<ClienteModel> ClientePorRazaoSocial(string RazaoSocial)
        {
            return await Task.Run(() => repo.List<ClienteModel>(c => c.RazaSocial.ToUpper().Equals(RazaoSocial.ToUpper())).SingleOrDefault());
        }
       
        public static async Task<bool> NovoClienteAsync(ClienteModel cliente)
        {
            await Task.Run(() => repo.Add<ClienteModel>(cliente));
            return true;
        }
    }
}