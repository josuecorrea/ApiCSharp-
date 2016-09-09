using log4net;
using Projeto.Api.Log;
using Projeto.Api.Repository;

namespace Projeto.Api.Services
{
    public static class LogService
    {
        //Log4Net grava em arquivo texto -- configurado no web.config
        public static void CriaLogFourNet(string tipo, string mensagem, string classe)
        {
            ILog log = LogManager.GetLogger(classe);

            if (tipo.ToUpper().Equals("ERROR"))
            {
                log.Error(mensagem);
            }
            else if (tipo.ToUpper().Equals("INFO"))
            {
                log.Info(mensagem);
            }
            else if (tipo.ToUpper().Equals("FATAL"))
            {
                log.Fatal(mensagem);
            }
            else
            {
                log.Info(mensagem);
            }
        }

        public static void CriaLogRedis(LogModel log)
        {
            RepositoryRedis.StoreDataAsync("Log", FactoryLog.CriaLog(log));
        }

        public static void CriaLogMongo(LogModel log)
        {
            using (MongoRepository repo = new MongoRepository())
            {
                repo.Add<LogModel>(log);
            }
        }
    }
}