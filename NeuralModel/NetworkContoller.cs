using System;

namespace NeuralModel {
    internal class NetworkContoller {
        private int layers = 3;
        private int inputs = 4;
        private int outputs = 4;

        internal void Start() {
            Console.WriteLine(new Network(layers, inputs, outputs).Outputs(new double[] { 3, 3, 3 }));
        }
    }
}