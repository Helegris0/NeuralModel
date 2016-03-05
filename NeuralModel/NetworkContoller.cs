using System;

namespace NeuralModel {
    internal class NetworkContoller {
        private double[] input = new double[] { 1, 2, 3, 4 };
        private int layers = 3;
        private int outputs = 4;

        internal void Start() {
            double[] result = new Network(layers, input.Length, outputs).Outputs(input);
            for (int i = 0; i < result.Length; i++) {
                Console.WriteLine(result[i]);
            }
        }
    }
}