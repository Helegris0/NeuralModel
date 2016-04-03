using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    class Cell<T> where T : IActivationFunction, new() {

        public Dictionary<Signal, double> InputsWithWeights { get; }
        public int NumberOfInputs { get; }

        public Cell(int numberOfInputs) {
            InputsWithWeights = new Dictionary<Signal, double>();
            NumberOfInputs = numberOfInputs;
        }

        public Cell(double[] weights) : this(weights.Length) {
            SetWeights(weights);
        }

        public void SetWeights(double[] weights) {
            InputsWithWeights.Clear();
            foreach (double weight in weights) {
                InputsWithWeights.Add(new Signal(), weight);
            }
        }

        public void SetInputs(double[] inputs) {
            if (inputs.Length == InputsWithWeights.Count) {
                int i = 0;

                foreach (Signal signal in InputsWithWeights.Keys) {
                    signal.SignalValue = inputs[i];
                    i++;
                }
            } else {
                throw new Exception("There should be " + InputsWithWeights.Count + " input values defined (instead of "+ inputs.Length + ").");
            }
        }

        private double FunctionInput() {
            double functionInput = 0;

            foreach (var item in InputsWithWeights) {
                if (item.Key.ValueIsSet) {
                    functionInput += item.Key.SignalValue * item.Value;
                } else {
                    throw new Exception("Some input value is not set.");
                }
            }

            return functionInput;
        }

        public double Output() {
            T function = new T();
            return function.FunctionResult(FunctionInput());
        }
    }
}
