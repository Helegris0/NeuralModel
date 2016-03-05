using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class Network {
        public List<Layer> Layers { get; }
        private Random random = new Random();

        public Network(int numberOfLayers, int numberOfInputs, int numberOfOutputs) {
            Layers = new List<Layer>();
            for (int i = 0; i < numberOfLayers; i++) {
                if (i == 0) {
                    Layers.Add(new Layer(numberOfInputs));
                } else if (i == numberOfLayers - 1) {
                    Layers.Add(new Layer(numberOfOutputs));
                } else if (numberOfInputs == numberOfOutputs) {
                    Layers.Add(new Layer(numberOfInputs));
                } else {
                    int min = numberOfInputs < numberOfOutputs ? numberOfInputs : numberOfOutputs;
                    int max = numberOfInputs > numberOfOutputs ? numberOfInputs : numberOfOutputs;
                    Layers.Add(new Layer(random.Next(min, max + 1)));
                }
            }
            SetNumbersOfInputs();
        }

        private void SetNumbersOfInputs() {
            for (int i = 0; i < Layers.Count; i++) {
                if (i == 0) {
                    Layers[i].NumberOfInputsPerCell = 1;
                } else {
                    Layers[i].NumberOfInputsPerCell = Layers[i - 1].NumberOfCells();
                }
            }
        }
    }
}
