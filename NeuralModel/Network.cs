using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class Network {
        private List<Layer> layers;
        private Random random = new Random();

        public Network(int numberOfLayers, int numberOfInputs, int numberOfOutputs) {
            layers = new List<Layer>();
            for (int i = 0; i < numberOfLayers; i++) {
                if (i == 0) {
                    layers.Add(new Layer(numberOfInputs));
                } else if (i == numberOfLayers - 1) {
                    layers.Add(new Layer(numberOfOutputs));
                } else if (numberOfInputs == numberOfOutputs) {
                    layers.Add(new Layer(numberOfInputs));
                } else {
                    int min = numberOfInputs < numberOfOutputs ? numberOfInputs : numberOfOutputs;
                    int max = numberOfInputs > numberOfOutputs ? numberOfInputs : numberOfOutputs;
                    layers.Add(new Layer(random.Next(min, max + 1)));
                }
            }
            SetNumbersOfInputs();
            DefaultWeightSettings();
            DefaultFunctionSettings();
        }

        private void SetNumbersOfInputs() {
            for (int i = 0; i < layers.Count; i++) {
                if (i == 0) {
                    layers[i].NumberOfInputsPerCell = 1;
                } else {
                    layers[i].NumberOfInputsPerCell = layers[i - 1].NumberOfCells();
                }
            }
        }

        private void DefaultWeightSettings() {
            double[][] firstLayerWeights = new double[layers[0].NumberOfCells()][];
            firstLayerWeights[0] = new double[] { 1 };
            for (int i = 1; i < firstLayerWeights.Length; i++) {
                firstLayerWeights[i] = new double[] { 0 };
            }

            for (int i = 1; i < layers.Count; i++) {
                layers[i].SetRandomWeights();
            }
        }

        private void DefaultFunctionSettings() {
            layers[0].SetActivationFunctionForAllCells(IdentityFunction.Instance);

            for (int i = 1; i < layers.Count; i++) {
                layers[i].SetActivationFunctionForAllCells(LogisticFunction.Instance);
            }
        }

        public double[] Outputs(double[] inputs) {
            if (inputs.Length == layers[0].NumberOfCells()) {
                layers[0].SetInputs(inputs);
                for (int i = 1; i < layers.Count; i++) {
                    layers[i].SetInputs(layers[i - 1].Outputs());
                }
                return layers[layers.Count].Outputs();
            } else if (layers[0].Cells.Count == 0) {
                throw new Exception("There are no cells in the first layer.");
            } else {
                throw new Exception(layers[0].NumberOfCells() + " input values should be defined (instead of " + inputs.Length + ")");
            }
        }
    }
}
