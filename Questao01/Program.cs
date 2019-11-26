using System;
using System.Linq;
using System.Collections.Generic;

namespace Console_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collection = new List<string>();
            bool again = false;
            do{
                System.Console.WriteLine("Digite uma sequencia de números separados por espaço:");
                string nums = Console.ReadLine();
                nums = nums.Trim();
                if (string.IsNullOrWhiteSpace(nums)){
                    again = true;
                    continue;
                }
                collection = nums.Split(' ').ToList();
            
                foreach (var item in collection)
                {
                    again = item.All(char.IsLetter);
                    if (again) break;
                }
            }
            while (again == true);

            List<int> numeros = new List<int>();
            collection.ForEach(c =>
            {
                numeros.Add(int.Parse(c));
            });

            System.Console.WriteLine("O maior número é:");
            System.Console.WriteLine(numeros.Max());
        }
    }
}
