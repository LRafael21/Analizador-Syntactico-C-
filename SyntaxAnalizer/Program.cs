using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SyntaxAnalyzer
{
    private List<(string language, Regex pattern)> languagePatterns;

    public SyntaxAnalyzer()
    {
        languagePatterns = new List<(string, Regex)>();

      

        // Patrones para lenguaje C#
        languagePatterns.Add(("C#", new Regex(@"^using\s+[\w\.]+;\s*$")));
        languagePatterns.Add(("C#", new Regex(@"^namespace\s+[\w\.]+[\s\n]*\{\s*$")));
        languagePatterns.Add(("C#", new Regex(@"^\s*(public|private|protected)?\s+(static\s+)?[\w\s\<\>]+\s+[\w]+\s*\(.*?\)\s*\{\s*$")));
        languagePatterns.Add(("C#", new Regex(@"^\s*Console\.WriteLine\(.+\);\s*$")));

        //Ejemplo de input para C#

        //        using System;

        //public class MyClass
        //    {
        ////        public static void Main(string[] args)
        //        {
        //            Console.WriteLine("Hello, world!");
        //        }
        //    }


        // Patrones para lenguaje Python
        languagePatterns.Add(("Python", new Regex(@"^import\s+[\w\.]+\s*$")));
        languagePatterns.Add(("Python", new Regex(@"^def\s+[\w]+\s*\(.*?\):\s*$")));
        languagePatterns.Add(("Python", new Regex(@"^\s*(class|async\s+def)\s+[\w]+\s*[\(|:].*?\)\s*:\s*$")));

        //Ejemplo de input para Python
        //        import math

        //def calculate_square(num):
        //    return num * num

           }

        public void Analyze(string code)
        {
            bool validSyntax = false;
            string validLanguage = "";

            foreach (var pattern in languagePatterns)
            {
                if (pattern.Item2.IsMatch(code))
                {
                    validSyntax = true;
                    validLanguage = pattern.language;
                    break;
                }
            }

            if (validSyntax)
            {
                Console.WriteLine("El código tiene sintaxis válida.");
                Console.WriteLine($"Lenguaje detectado: {validLanguage}");
                Console.WriteLine("Código ingresado:");
                Console.WriteLine(code);
            }
            else
            {
                Console.WriteLine("El código no tiene sintaxis válida.");
                Console.WriteLine("Código ingresado:");
                Console.WriteLine(code);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            SyntaxAnalyzer analyzer = new SyntaxAnalyzer();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Analizador Sintáctico ====");
                Console.WriteLine();
                Console.WriteLine("Ingrese el código a analizar (o escriba 'salir' para terminar):");
                string code = Console.ReadLine();

                if (code.ToLower() == "salir")
                    break;

                Console.Clear();
                Console.WriteLine("==== Resultado del Análisis ====");
                Console.WriteLine();
                analyzer.Analyze(code);
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
