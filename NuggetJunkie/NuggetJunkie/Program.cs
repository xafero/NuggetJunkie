using CommandLine;
using log4net;
using log4net.Config;
using NuggetJunkie.Core;
using System.IO;
using System.Linq;

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
            const string packFile = "packages.config";
            foreach (var projFile in ProjectModel.FindFiles(o.Project))
            {
                var proj = ProjectModel.LoadFile(projFile);
                foreach (var refi in proj.Entries.Where(e => e.HintPath != null))
                {
                    var path = Path.GetFullPath(Path.Combine(proj.ProjectDirectory, refi.HintPath));

                }
                var packPath = Path.Combine(proj.ProjectDirectory, packFile);
                Packages model;
                if (File.Exists(packPath))
                    model = PackageModel.LoadFile(packPath);
                else
                    model = new Packages();
                PackageModel.StoreFile(model, packPath);
            }
        }
    }
}