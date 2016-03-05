using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class Cell {
        public Dictionary<Signal, double> InputsWithWeights { get; }
        public IActivationFunction ActivationFunction { get; set; }
        public int NumberOfInputs { get; set; }

        public Cell() {
        }

        public Cell(double[] weights) {
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
                throw new Exception("There should be " + InputsWithWeights.Count + " input values defined.");
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
            return ActivationFunction.FunctionResult(FunctionInput());
        }
    }
}
