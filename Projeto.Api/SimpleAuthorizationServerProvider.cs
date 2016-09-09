using Microsoft.Owin.Security.OAuth;
using Projeto.Api.Log;
using Projeto.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto.Api
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var header = context.OwinContext.Response.Headers.SingleOrDefault(h => h.Key == "Access-Control-Allow-Origin");
            if (header.Equals(default(KeyValuePair<string, string[]>)))
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            }

            UsuarioService.AdicionaUsuarioMaster();

            var user = UsuarioService.Autentica(context.Password, context.UserName);

            if (user == null)
            {
                #region Log
                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "SimpleAuthorizationServerProvider",
                    Controller = "",
                    Data = DateTime.Now,
                    Linha = 29,
                    Mensagem = "Usuário não encontrado: " + context.UserName,
                    Metodo = "GrantResourceOwnerCredentials",
                    Tipo = Tipo.Erro,
                    QtdeRegistrosRetornados = 0
                });
                #endregion

                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

            #region Log
            LogService.CriaLogMongo(new LogModel
            {
                Classe = "SimpleAuthorizationServerProvider",
                Controller = "",
                Data = DateTime.Now,
                Linha = 29,
                Mensagem = "Usuário Autorizado: " + context.UserName + " AuthenticantionType: " + identity.AuthenticationType + " IsAuthenticated: " + identity.IsAuthenticated,
                Metodo = "GrantResourceOwnerCredentials",
                Tipo = Tipo.Info,
                QtdeRegistrosRetornados = 1
            });
            #endregion
        }
    }
}