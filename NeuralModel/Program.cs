using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    class Program {

        static double[] input = new double[] { 1, 2, 3, 4 };
        static int layers = 3;
        static int outputs = 4;

        static void Main(string[] args) {
            Console.WriteLine("Input:");
            for (int i = 0; i < input.Length; i++) {
                Console.WriteLine(input[i]);
            }

            double[] result = new Network(layers, input.Length, outputs).Outputs(input);

            Console.WriteLine("Output:");
            for (int i = 0; i < result.Length; i++) {
                Console.WriteLine(result[i]);
            }

            Console.ReadKey();
        }
    }
}
