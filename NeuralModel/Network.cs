using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    class Network {

        private List<ILayer> layers;
        private Random random = new Random();

        public Network(int numberOfLayers, int numberOfInputs, int numberOfOutputs) {
            layers = new List<ILayer>();

            layers.Add(new FirstLayer<IdentityFunction>(numberOfInputs));

            int min = numberOfInputs < numberOfOutputs ? numberOfInputs : numberOfOutputs;
            int max = numberOfInputs > numberOfOutputs ? numberOfInputs : numberOfOutputs;
            for (int i = 1; i < numberOfLayers - 1; i++) {
                int numCells = random.Next(min, max + 1);
                int numInputs = layers[i - 1].NumberOfCells();
                layers.Add(new OtherLayer<LogisticFunction>(numCells, numInputs));
            }

            int numInputsLastLayer = layers[numberOfLayers - 2].NumberOfCells();
            layers.Add(new OtherLayer<LogisticFunction>(numberOfOutputs, numInputsLastLayer));

            DefaultWeightSettings();
        }

        private void DefaultWeightSettings() {
            layers.ForEach(layer => layer.SetDefaultWeights());
        }

        public double[] Outputs(double[] inputs) {
            if (inputs.Length == layers[0].NumberOfCells()) {
                layers[0].SetInputs(inputs);
                for (int i = 1; i < layers.Count; i++) {
                    layers[i].SetInputs(layers[i - 1].Outputs());
                }
                return layers[layers.Count - 1].Outputs();
            } else if (layers[0].NumberOfCells() == 0) {
                throw new Exception("There are no cells in the first layer.");
            } else {
                throw new Exception(layers[0].NumberOfCells() + " input values should be defined (instead of " + inputs.Length + ")");
            }
        }
    }
}
