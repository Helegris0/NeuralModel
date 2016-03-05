using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class Layer {
        public List<Cell> Cells { get; }
        public int NumberOfInputsPerCell {
            get { return NumberOfInputsPerCell; }
            set {
                NumberOfInputsPerCell = value;
                Cells.ForEach(cell => cell.NumberOfInputs = value);
            }
        }

        private Random random = new Random();
        private double randomMin = -1;
        private double randomMax = 1;

        public Layer(int numberOfCells) {
            Cells = new List<Cell>();
            for (int i = 0; i < numberOfCells; i++) {
                Cells.Add(new Cell());
            }
        }

        public int NumberOfCells() {
            return Cells.Count;
        }

        public void SetActivationFunctionForAllCells(IActivationFunction function) {
            Cells.ForEach(cell => cell.ActivationFunction = function);
        }

        public void SetWeights(double[][] weights) {
            for (int i = 0; i < weights.Length; i++) {
                double[] weightsForCell = weights[i];
                Cells[i].SetWeights(weightsForCell);
            }
        }

        public void SetRandomWeights() {
            Cells.ForEach(cell => {
                double[] weightsForCell = new double[cell.NumberOfInputs];
                for (int i = 0; i < cell.NumberOfInputs; i++) {
                    double weight = random.NextDouble() * (randomMax - randomMin) + randomMin;
                    weightsForCell[i] = weight;
                }
                cell.SetWeights(weightsForCell);
            });
        }

        public void SetInputs(double[] inputs) {
            Cells.ForEach(cell => cell.SetInputs(inputs));
        }

        public double[] Outputs() {
            double[] outputs = new double[NumberOfCells()];
            for (int i = 0; i < NumberOfCells(); i++) {
                outputs[i] = Cells[i].Output();
            }
            return outputs;
        }
    }
}
