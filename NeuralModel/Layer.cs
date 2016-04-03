using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    abstract class Layer<T> : ILayer where T : IActivationFunction, new() {

        public List<Cell<T>> Cells { get; }

        public Layer(int numberOfCells, int numberOfInputs) {
            Cells = new List<Cell<T>>();

            for (int i = 0; i < numberOfCells; i++) {
                Cells.Add(new Cell<T>(numberOfInputs));
            }
        }

        public int NumberOfCells() {
            return Cells.Count;
        }

        public abstract void SetDefaultWeights();

        public void SetWeights(double[][] weights) {
            for (int i = 0; i < weights.Length; i++) {
                double[] weightsForCell = weights[i];
                Cells[i].SetWeights(weightsForCell);
            }
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
