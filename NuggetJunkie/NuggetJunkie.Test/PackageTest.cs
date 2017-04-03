using NuggetJunkie.Core;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using static NUnit.Framework.Assert;

namespace NuggetJunkie.Test
{
    [TestFixture]
    public class PackageTest
    {
        static readonly string root = Environment.CurrentDirectory;

        [Test]
        public void ShouldListPackages()
        {
            var files = PackageModel.FindFiles(root);
            AreEqual(3, files.Length);
            var file1 = files.First();
            var model1 = PackageModel.LoadFile(file1);
            AreEqual("{'Id':'CommandLineParser','Version':'2.1.1-beta','TargetFramework':'net451'}",
                model1.Entries.First().ToJson());
            var file2 = files.Last();
            var model2 = PackageModel.LoadFile(file2);
            AreEqual("{'Id':'Newtonsoft.Json','Version':'10.0.2','TargetFramework':'net451'}",
                model2.Entries.First().ToJson());
        }

        [Test]
        public void ShouldWritePackages()
        {
            var model = new Packages
            {
                Entries =
                {
                    new Package {Id="NuGet",Version="1.2.3",TargetFramework="net451" },
                    new Package {Id="NUnit",Version="4.5.6",TargetFramework="mono203" }
                }
            };
            var file = Path.GetTempFileName();
            PackageModel.StoreFile(model, file);
            IsTrue(File.Exists(file));
            try
            {
                model = PackageModel.LoadFile(file);
                AreEqual(2, model.Entries.Count);
                AreEqual("{'Id':'NuGet','Version':'1.2.3','TargetFramework':'net451'}",
                    model.Entries.First().ToJson());
            }
            finally
            {
                File.Delete(file);
            }
        }

        [Test]
        public void ShouldNotChangePackages()
        {
            var files = PackageModel.FindFiles(root);
            var file = files.First();
            var model = PackageModel.LoadFile(file);
            var copy = Path.GetTempFileName();
            PackageModel.StoreFile(model, copy);
            IsTrue(File.Exists(file));
            try
            {
                var textA = File.ReadAllText(file);
                var textB = File.ReadAllText(copy);
                AreEqual(textA, textB);
            }
            finally
            {
                File.Delete(copy);
            }
        }
    }
}