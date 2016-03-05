using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class Cell {
        public NetworkProperties NetworkProps { get; }
        public Dictionary<Signal, double> InputsWithWeights { get; }
        public IActivationFunction ActivationFunction { get; }

        public Cell(NetworkProperties networkProps) {
            NetworkProps = networkProps;
        }

        public Cell(NetworkProperties networkProps, double[] weights) : this(networkProps) {
            SetWeights(weights);
        }

        public void SetWeights(double[] weights) {
            int expectedAmount = NetworkProps.NumberOfInputs;
            if (weights.Length == expectedAmount) {
                InputsWithWeights.Clear();
                foreach (double weight in weights) {
                    InputsWithWeights.Add(new Signal(), weight);
                }
            } else {
                throw new Exception("There should be " + expectedAmount + " values defined as weights.");
            }
        }

        public void SetInputs(double[] inputs) {
            int expectedAmount = NetworkProps.NumberOfInputs;
            if (inputs.Length == expectedAmount) {
                int i = 0;
                foreach (Signal signal in InputsWithWeights.Keys) {
                    signal.SignalValue = inputs[i];
                    i++;
                }
            } else {
                throw new Exception("There should be " + expectedAmount + " input values defined.");
            }
        }

        public int NumberOfInputs() {
            return InputsWithWeights.Count;
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
