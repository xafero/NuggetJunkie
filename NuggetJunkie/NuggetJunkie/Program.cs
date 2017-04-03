using CommandLine;
using log4net;
using log4net.Config;
using NuggetJunkie.Core;

namespace NuggetJunkie
{
    class Program
    {
        static readonly ILog log = LogManager.GetLogger(typeof(Program).Namespace);

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            using (var parser = Parser.Default)
                parser.ParseArguments<Options>(args).WithParsed(Process);
        }

        static void Process(Options o)
        {
            foreach (var proj in ProjectModel.FindFiles(o.Project))
            {

            }
        }
    }
}