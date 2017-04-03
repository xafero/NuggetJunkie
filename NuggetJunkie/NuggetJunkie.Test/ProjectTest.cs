using NuggetJunkie.Core;
using NUnit.Framework;
using System;
using System.Linq;
using static NUnit.Framework.Assert;

namespace NuggetJunkie.Test
{
    [TestFixture]
    public class ProjectTest
    {
        static readonly string root = Environment.CurrentDirectory;

        [Test]
        public void ShouldListRefs()
        {
            var files = ProjectModel.FindFiles(root);
            AreEqual(3, files.Length);
            var file1 = files.First();
            var model1 = ProjectModel.LoadFile(file1);
            AreEqual("'HintPath':'..\\", model1.Entries.First()
                .ToJson().Substring(1, 15));
            var file2 = files.Last();
            var model2 = ProjectModel.LoadFile(file2);
            AreEqual("'HintPath':'..\\", model1.Entries.First()
                .ToJson().Substring(1, 15));
        }
    }
}