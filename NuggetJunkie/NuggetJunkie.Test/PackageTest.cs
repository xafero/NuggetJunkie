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
            var files = Directory.GetFiles(root, "pack*.conf*", SearchOption.AllDirectories);
            AreEqual(2, files.Length);
            var file1 = files.First();
            var model1 = PackageModel.LoadFile(file1);
            AreEqual("?", model1);
            var file2 = files.Last();
            var model2 = PackageModel.LoadFile(file2);
            AreEqual("?", model2);
        }
    }
}