using CommandLine;
using log4net;
using log4net.Config;
using NuggetJunkie.Core;
using System;
using System.Collections.Generic;
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
                var packPath = Path.Combine(proj.ProjectDirectory, packFile);
                Packages model;
                if (File.Exists(packPath))
                    model = PackageModel.LoadFile(packPath);
                else
                    model = new Packages();
                var entries = new List<Package>();
                foreach (var refi in proj.Entries.Where(e => e.HintPath != null))
                {
                    var path = Path.GetFullPath(Path.Combine(proj.ProjectDirectory, refi.HintPath));
                    var refName = refi.HintPath.Split(new[] { refi.Info.Version.ToString() },
                        StringSplitOptions.None).First().TrimEnd('.')
                        .Split(Path.DirectorySeparatorChar).Last();
                    var refVer = refi.Info.Version.ToString();
                    if (refName?.EndsWith(".dll") ?? false)
                        refName = refName.Replace(".dll", "");
                    var refFrame = proj.TargetFramework.Replace("v4", "net4").Replace(".", "");
                    entries.Add(new Package
                    {
                        Id = refName,
                        Version = refVer,
                        TargetFramework = refFrame
                    });
                }
                foreach (var entry in entries.OrderBy(e => e.Id))
                {
                    var tgt = model.Entries.FirstOrDefault(e => e.Id == entry.Id);
                    if (tgt == null)
                    {
                        model.Entries.Add(entry);
                        continue;
                    }
                    tgt.Id = entry.Id;
                    tgt.TargetFramework = entry.TargetFramework;
                    tgt.Version = entry.Version;
                }
                PackageModel.StoreFile(model, packPath);
            }
        }
    }
}