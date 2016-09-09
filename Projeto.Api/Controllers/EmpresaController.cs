using Projeto.Api.Dominio.Empresa;
using Projeto.Api.Helpers;
using Projeto.Api.Services;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace Projeto.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class EmpresaController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("empresa/listadeempresas")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<IHttpActionResult> GetAllEmpreas()
        {
            return Ok(await EmpresaService.ListaDeEmpresasAsync());
        }

        [HttpGet]
        [Authorize]
        [Route("empresa/listadeempresaspaginado/{page}/{size}")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<IHttpActionResult> GetEmpresasPaginado(int page, int size)
        {
            return Ok(await EmpresaService.ListaDeUsuariosPaginadosAsync(page, size));
        }

        [HttpGet]
        [Authorize]
        [Route("empresa/empresaporusuario/{usuarioid}")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<IHttpActionResult> GetEmpresasPorUsuario(string usuarioId)
        {
            return Ok(await EmpresaService.ListaDeEmpresasPorUsuarioAsync(usuarioId));
        }

        [HttpPost]
        [Authorize]
        [Route("empresa/novo")]
        public async Task<IHttpActionResult> NovoEmpresa(EmpresaModel empresa)
        {
            return Ok(await EmpresaService.NovaEmpresaAsync(empresa));
        }
    }
}