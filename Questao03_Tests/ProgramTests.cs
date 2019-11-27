using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Questao03_Tests
{
    public class ProgramTests
    {
        [Fact]
        public void CriarDiretorio_OK()
        {
            Questao03.Program.CriarDiretorio(out string path);
            Assert.True(Directory.Exists(path));
        }

        [Theory]
        [InlineData("/home/Imagens/", "/home/copias/")]
        public void CopiarDe_OK(string fromPath, string wherePath)
        {
            Questao03.Program.CopiarDe(fromPath, wherePath);
            List<byte[]> filesInWhere = new List<byte[]>();
            List<byte[]> filesInFrom = new List<byte[]>();

            foreach (var item in Directory.EnumerateFiles(wherePath))
            {
                filesInWhere.Add(File.ReadAllBytes(item));
            }

            foreach(var item in Directory.EnumerateFiles(fromPath))
            {
                filesInFrom.Add(File.ReadAllBytes(item));
            }

            Assert.True(filesInFrom.Except(filesInWhere).Any());
        }
    }
}
