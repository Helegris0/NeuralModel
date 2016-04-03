using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    class OtherLayer<T> : Layer<T> where T : IActivationFunction, new() {

        private Random random = new Random();
        private double randomMin = -1;
        private double randomMax = 1;

        public OtherLayer(int numberOfCells, int numberOfInputs) : base(numberOfCells, numberOfInputs) {
        }

        public override void SetDefaultWeights() {
            SetRandomWeights();
        }

        private void SetRandomWeights() {
            Cells.ForEach(cell => {
                double[] weightsForCell = new double[cell.NumberOfInputs];

                for (int i = 0; i < cell.NumberOfInputs; i++) {
                    double weight = random.NextDouble() * (randomMax - randomMin) + randomMin;
                    weightsForCell[i] = weight;
                }

                cell.SetWeights(weightsForCell);
            });
        }
    }
}
