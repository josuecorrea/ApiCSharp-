using Projeto.Api.Dominio.Cliente;
using Projeto.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.OutputCache.V2;

namespace Projeto.Api.Controllers
{
    [System.Web.Http.RoutePrefix("api/v1")]
    public class ClienteController : ApiController
    {

        [System.Web.Http.HttpGet]
        [System.Web.Http.Authorize]
        [System.Web.Http.Route("cliente/listadeclientes")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<System.Web.Http.IHttpActionResult> GetAllClientes()
        {
            return Ok(await ClienteService.ListaDeClientesAsync());
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Authorize]
        [System.Web.Http.Route("cliente/buscarclienteporcnpjcpf/{cnpjcpf}")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<IHttpActionResult> GetClienteCNPJCPF(string CNPJCPF)
        {
            return Ok(await ClienteService.ClientePorCNPJCPF(CNPJCPF));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Authorize]
        [System.Web.Http.Route("cliente/buscarclienteporrazaosocial/{razaosocial}")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<IHttpActionResult> GetClienteRazaoSocial(string razaoSocial)
        {
            return Ok(await ClienteService.ClientePorRazaoSocial(razaoSocial));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize]
        [System.Web.Http.Route("cliente/novo")]
        public async Task<IHttpActionResult> NovoEmpresa(ClienteModel cliente)
        {
            return Ok(await ClienteService.NovoClienteAsync(cliente));
        }
    }
        
}