using Projeto.Api.Dominio.Usuario;
using Projeto.Api.Helpers;
using Projeto.Api.Log;
using Projeto.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Api.Services
{
    public static class UsuarioService
    {
        private static readonly MongoRepository _repo = new MongoRepository();
        private static readonly RepositoryRedis _redisRepository = new RepositoryRedis();

        public static async Task<List<UsuarioModel>> ListaDeUsuariosAsync()
        {
            try
            {
                return await Task.Run(() => _repo.All<UsuarioModel>().ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<List<UsuarioModel>> ListaDeUsuariosPaginadosAsync(int page, int size)
        {
            try
            {
                if (await _redisRepository.Exists("usuarios"))
                {
                    return await _redisRepository.GetListPaginadaAsync<UsuarioModel>("usuarios", page, size);
                }

                return await Task.Run(() => _repo.All<UsuarioModel>(page, size).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> NovoUsuario(UsuarioModel usuario)
        {
            try
            {
                await Task.Run(() => _repo.Add<UsuarioModel>(usuario));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> ExcluiUsuario(UsuarioModel usuario)
        {
            try
            {
                await Task.Run(() => _repo.Delete<UsuarioModel>(usuario));
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> DesativaUsuario(UsuarioModel usuario)
        {
            try
            {
                await Task.Run(() =>
                {
                    var user = _repo.Single<UsuarioModel>(c => c.CpfCnpj.Equals(usuario.CpfCnpj));

                    user.Ativo = false;

                    _repo.Add<UsuarioModel>(user);
                });

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<UsuarioModel> ListaUsuarioPorNomeAsync(string username)
        {
            try
            {
                var tt = _repo.Single<UsuarioModel>(c => c.Nome.Equals(username));
                return await Task.Run(() => _repo.Single<UsuarioModel>(c => c.Nome.Equals(username)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<UsuarioModel> ListaUsuarioPorNome(string username)
        {
            try
            {
                var tt = _repo.List<UsuarioModel>(c => c.Nome == username).ToList();
                return tt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AdicionaUsuarioMaster()
        {
            var novoUsurio = new UsuarioModel
            {
                Ativo = true,
                Celular = "0000000000",
                CpfCnpj = "00000000000000",
                DataCadastro = DateTime.Now,
                Fixo = "0000000000",
                Master = true,
                Nome = "Master",
                Password = Crypto.Encrypt("123456"),
                UserName = "master",
                Tenant = true,
                LimiteEmpresas = 100000000,
                MinhasEmpresas = null,
                TipoUsuario = "Administrador"
            };

            var userMaster = _repo.Single<UsuarioModel>(c => c.UserName == novoUsurio.UserName && c.Password == novoUsurio.Password);
            if (userMaster == null)
            {
                _repo.Add<UsuarioModel>(novoUsurio);

                LogService.CriaLogMongo(new LogModel
                {
                    Classe = "UsuarioService",
                    Controller = "",
                    Data = DateTime.Now,
                    Linha = 86,
                    Mensagem = "Usuário Master criado",
                    Metodo = "AdicionaUsuarioMaster",
                    Tipo = Tipo.Info,
                    QtdeRegistrosRetornados = 1
                });
            }
        }

        public async static Task<UsuarioModel> Autentica(string senha, string usuario)
        {
            try
            {
                senha = Crypto.Encrypt(senha);

                UsuarioModel result = new UsuarioModel();

                if (await _redisRepository.Exists("usuarios"))
                {
                    var buscaRedis = await _redisRepository.GetListAsync<UsuarioModel>("usuarios");

                    if (buscaRedis.Count > 0)
                    {
                        result = buscaRedis.SingleOrDefault(c => c.UserName == usuario && c.Password == senha);

                        if (result.UserName == null)
                        {
                            result = _repo.Single<UsuarioModel>(c => c.UserName == usuario && c.Password == senha);
                            await _redisRepository.AddAsync<UsuarioModel>("usuarios", result, new DateTimeOffset(new DateTime(2020, 12, 01)));
                        }
                    }
                }
                else
                {
                    result = _repo.Single<UsuarioModel>(c => c.UserName == usuario && c.Password == senha);
                    await _redisRepository.AddAsync<UsuarioModel>("usuarios", result, new DateTimeOffset(new DateTime(2020, 12, 01)));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}