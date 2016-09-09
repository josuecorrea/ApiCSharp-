using Projeto.Api.Dominio.Empresa;
using Projeto.Api.Dominio.Usuario;
using Projeto.Api.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Api.Services
{
    public static class EmpresaService
    {
        private static readonly MongoRepository repo = new MongoRepository();

        public static async Task<List<EmpresaModel>> ListaDeEmpresasAsync()
        {
            return await Task.Run(() => repo.All<EmpresaModel>().ToList());
        }

        public static async Task<List<EmpresaModel>> ListaDeUsuariosPaginadosAsync(int page, int size)
        {
            return await Task.Run(() => repo.All<EmpresaModel>(page, size).ToList());
        }

        public static async Task<List<UsuarioEmpresaModel>> ListaDeEmpresasPorUsuarioAsync(string cpf)
        {
            return await Task.Run(() => repo.List<UsuarioEmpresaModel>(c => c.Cnpj.Equals(cpf)).ToList());
        }

        public static async Task<bool> NovaEmpresaAsync(EmpresaModel empresa)
        {
            await Task.Run(() => repo.Add<EmpresaModel>(empresa));

            return true;
        }
    }
}