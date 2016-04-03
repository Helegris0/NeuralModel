using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    class FirstLayer<T> : Layer<T> where T : IActivationFunction, new() {

        public FirstLayer(int numberOfInputs) : base(numberOfInputs, numberOfInputs) {
        }

        public override void SetDefaultWeights() {
            for (int i = 0; i < Cells.Count; i++) {
                double[] weights = new double[Cells[i].NumberOfInputs];

                for (int j = 0; j < Cells[i].NumberOfInputs; j++) {
                    if (i == j) {
                        weights[j] = 1;
                    } else {
                        weights[j] = 0;
                    }
                }

                Cells[i].SetWeights(weights);
            }
        }
    }
}
