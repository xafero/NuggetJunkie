using NuggetJunkie.Core;
using NUnit.Framework;
using System;
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
            AreEqual(2, files.Length);
            var file1 = files.First();
            var model1 = PackageModel.LoadFile(file1);
            AreEqual("{'Id':'CommandLineParser','Version':'2.1.1-beta','TargetFramework':'net451'}",
                model1.Entries.First().ToJson());
            var file2 = files.Last();
            var model2 = PackageModel.LoadFile(file2);
            AreEqual("{'Id':'Newtonsoft.Json','Version':'10.0.2','TargetFramework':'net451'}",
                model2.Entries.First().ToJson());
        }
    }
}