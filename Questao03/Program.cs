using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Questao03
{
    public class Program
    {
        public static bool IsLinux
        {
            get 
            {
                int p = (int) Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        public static void CriarDiretorio(out string path)
        {
            path = IsLinux ? "/home/copias/" : "C:/copias/";
            System.Console.WriteLine("Criando diretório onde as imagens serão armazenadas...");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void CopiarDe(string fromPath, string wherePath)
        {
            if (string.IsNullOrWhiteSpace(fromPath) || string.IsNullOrWhiteSpace(wherePath))
                throw new ArgumentNullException();

            if (Directory.Exists(fromPath))
            {
                var images = Directory.EnumerateFiles(fromPath);

                foreach (var img in images)
                {
                    var fileName = img.Split('/').Last();
                    var file = File.ReadAllBytes(img);
                    File.WriteAllBytes(wherePath + fileName, file);
                }
            }
            System.Console.WriteLine("Arquivos salvos!");
        }
        // Iniciar como administrador
        static void Main(string[] args)
        {
            CriarDiretorio(out string path);

            System.Console.WriteLine("Digite um diretório para copiar as imagens:");
            string copyFrom = Console.ReadLine();

            CopiarDe(copyFrom, path);
        }
    }
}
