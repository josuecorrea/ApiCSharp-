using Newtonsoft.Json;

namespace Projeto.Api.Log
{
    public static class FactoryLog
    {
        public static string CriaLog(LogModel log)
        {
            var msg = JsonConvert.SerializeObject(log);

            return msg;
        }
    }
}