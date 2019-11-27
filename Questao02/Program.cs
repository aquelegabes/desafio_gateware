using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Questao02
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyPath = Path.GetFullPath(Assembly.GetEntryAssembly().Location);
            var filesPath = assemblyPath.Replace("bin/Debug/netcoreapp2.2/Questao02.dll", "Arquivos");

            // declarando numeros
            List<string> telefones = new List<string>();

            // lendo arquivos
            foreach (var file in Directory.EnumerateFiles(filesPath, "*.txt"))
            {
                string contents = File.ReadAllText(file);
                var conteudos = contents.Split(';');
                if (conteudos == null)
                    break;
                foreach (var item in conteudos)
                {
                    var isValid = item.Contains("+");
                    isValid = isValid && item.Substring(1,item.Length-1).All(char.IsDigit);
                    isValid = isValid && item.Length >= 9;
                    if (isValid == false) break;

                    telefones.Add(item);
                }
            }

            System.Console.WriteLine($"Numeros encontrados {telefones?.Count ?? 0}");
            if (telefones?.Count >= 1)
                telefones.ForEach(System.Console.WriteLine);
        }
    }
}
