using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValorCardinalPortugalCall
{
    class Program
    {
        static void Main(string[] args)
        {
			System.Console.WriteLine("");
			System.Console.WriteLine("ValorCardinalPortugal (Version: 1.0.3)");
			System.Console.WriteLine("======================================");
			System.Console.WriteLine("");

			System.Console.Write("Introduza valor '#0.00':");
			string valor = System.Console.ReadLine();

			System.Console.WriteLine("");
			System.Console.WriteLine("Processa :[" + valor + "]");
			System.Console.WriteLine("");

			// executa
			Candal.ValorCardinalPortugal objIns = new Candal.ValorCardinalPortugal();
			String resultado = objIns.Converte(valor);

			System.Console.WriteLine("Resultado:[" + resultado + "]\n");
			System.Console.WriteLine("");

			//int enter = System.Console.Read();
		}
    }
}
