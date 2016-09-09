using Newtonsoft.Json;
using Projeto.Api.Dominio.Usuario;
using Projeto.Api.Helpers;
using Projeto.Api.Log;
using Projeto.Api.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Tracing;
using WebApi.OutputCache.V2;

namespace Projeto.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("usuario/listadeusuarios")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            try
            {
                Configuration.Services.GetTraceWriter().Info(
               Request, "UsuarioController", "Lista de usuários.");

                var result = await UsuarioService.ListaDeUsuariosAsync();

                #region Log

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioModel",
                    Controller = "UsuarioController",
                    Data = DateTime.Now,
                    Linha = 30,
                    Mensagem = "Retornado com sucesso",
                    Metodo = "listadeusuarios",
                    Tipo = Tipo.Info,
                    QtdeRegistrosRetornados = result.Count
                });

                #endregion Log

                return Ok(result);
            }
            catch (Exception ex)
            {

                #region Log

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioModel",
                    Controller = "UsuarioController",
                    Data = DateTime.Now,
                    Linha = 30,
                    Mensagem = "Erro: " + ex.Message + " Stack: " + ex.StackTrace,
                    Metodo = "listadeusuarios",
                    Tipo = Tipo.Erro,
                    QtdeRegistrosRetornados = 0
                });

                #endregion Log

                return Content(HttpStatusCode.BadRequest, "Erro: " + ex.Message);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("usuario/listadeusuariospaginado/{page}/{size}")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public async Task<IHttpActionResult> GetUsers(int page, int size)
        {
            try
            {
                Configuration.Services.GetTraceWriter().Info(
                Request, "UsuarioController", "Lista de usuários paginada.");

                var result = await UsuarioService.ListaDeUsuariosPaginadosAsync(page, size);

                #region Log

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioModel",
                    Controller = "UsuarioController",
                    Data = DateTime.Now,
                    Linha = 42,
                    Mensagem = "Retornou lida de usario paginado: " + page + "/" + size,
                    Metodo = "listadeusuariospaginado",
                    Tipo = Tipo.Info,
                    QtdeRegistrosRetornados = result.Count
                });

                #endregion Log

                return Ok(result);
            }
            catch (Exception ex)
            {
                #region log

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioModel",
                    Controller = "UsuarioController",
                    Data = DateTime.Now,
                    Linha = 42,
                    Mensagem = "Erro:" + ex.Message + ex.StackTrace,
                    Metodo = "listadeusuariospaginado",
                    Tipo = Tipo.Erro,
                    QtdeRegistrosRetornados = 0
                });

                #endregion log

                return Content(HttpStatusCode.BadRequest, "Erro: " + ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("usuario/novo")]
        public async Task<IHttpActionResult> PostUsers(UsuarioModel usuario)
        {
            try
            {
                Configuration.Services.GetTraceWriter().Info(
               Request, "UsuarioController", "Lista de usuários paginada.");

                var addusuario = await UsuarioService.NovoUsuario(usuario);

                #region log

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioModel",
                    Controller = "UsuarioController",
                    Data = DateTime.Now,
                    Linha = 42,
                    Mensagem = "Usuário adicionado: " + JsonConvert.SerializeObject(usuario),
                    Metodo = "PostUsers",
                    Tipo = Tipo.Erro,
                    QtdeRegistrosRetornados = 1
                });

                #endregion log

                return Content(HttpStatusCode.Created, "Usuário adicionado");
            }
            catch (Exception ex)
            {
                #region log

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioModel",
                    Controller = "UsuarioController",
                    Data = DateTime.Now,
                    Linha = 137,
                    Mensagem = "Erro:" + ex.Message + ex.StackTrace,
                    Metodo = "PostUsuarios",
                    Tipo = Tipo.Erro,
                    QtdeRegistrosRetornados = 0
                });

                #endregion log

                return Content(HttpStatusCode.BadRequest, "Erro: " + ex.Message);
            }

        }

        [HttpGet]
        [Authorize]
        [Route("usuario/buscausuariopornome/{nome}")]
        [CacheOutput(ClientTimeSpan = 1000, ServerTimeSpan = 1000)]
        //[DeflateCompression]
        public IHttpActionResult GetUserForName(string nome)
        {
            try
            {
                Configuration.Services.GetTraceWriter().Info(
               Request, "UsuarioController", "Lista de usuários paginada.");

                return Ok(UsuarioService.ListaUsuarioPorNome(nome));
            }
            catch (Exception ex)
            {
                #region log

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioModel",
                    Controller = "UsuarioController",
                    Data = DateTime.Now,
                    Linha = 190,
                    Mensagem = "Erro:" + ex.Message + ex.StackTrace,
                    Metodo = "Busca usuario por nome",
                    Tipo = Tipo.Erro,
                    QtdeRegistrosRetornados = 0
                });

                #endregion log

                return Content(HttpStatusCode.BadRequest, "Erro: " + ex.Message);
            }
        }
    }
}