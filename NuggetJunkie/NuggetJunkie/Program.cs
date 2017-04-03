using log4net;
using log4net.Config;

namespace NuggetJunkie
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program).Namespace);

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            log.InfoFormat("Done.");
        }
    }
}