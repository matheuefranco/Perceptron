using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = new int[4, 2] { { 1, 1 }, { 1, 0 }, { 0, 1 }, { 0, 0 } };
            int[] real = {1, 0, 0, 0 }; // label - saída
            Random r = new Random();
            double[] pesos = { r.NextDouble(), r.NextDouble(), r.NextDouble() }; //{ 1, 1, 1 };//
            Console.Write("Pesos iniciais:" + pesos[0] + " " + pesos[1] + " " + pesos[2] + " \n");
            double taxaAprendizagem = 0.1;
            double totalError;
            do
            {
                totalError = 0;
                for (int i = 0; i < 4; i++)
                {
                    int saida = funcaoAtivacao(input[i, 0], input[i, 1], pesos); // calcula a saida de acordo com a funcao de ativacao
                    int error = real[i] - saida;
                    pesos[0] += taxaAprendizagem * error * input[i, 0];
                    pesos[1] += taxaAprendizagem * error * input[i, 1];
                    pesos[2] += taxaAprendizagem * error * 1; // bias - constante
                    Console.Write("Pesos:" + pesos[0] + " " + pesos[1] + " " + pesos[2] + " \n");
                    totalError += Math.Abs(error);
                }// fim for
                Console.WriteLine("Total Error:" + totalError);
            } while (totalError > 0.2);

            Console.WriteLine("Results:");
            for (int i = 0; i < 4; i++)
                Console.Write("A: "+input[i, 0] + " B: " + input[i, 1] + "=" + funcaoAtivacao(input[i, 0], input[i, 1], pesos) + "\n");

            do
            {
                Console.WriteLine("\nEntre com dois valores:");
                int A = int.Parse(Console.ReadLine());
                int B = int.Parse(Console.ReadLine());
                Console.WriteLine("Resultado:"+funcaoAtivacao(A, B, pesos));
            } while (true);
            Console.ReadLine(); 

        }// fim main
        private static int funcaoAtivacao(double x0, double x1,double[] pesos)
        {
            double soma = x0 * pesos[0] + x1 * pesos[1] + 1 * pesos[2];
            return (soma >= 1) ? 1 : 0; // funcao de ativacao degrau
        }
    }
}
