using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class LogisticFunction : IActivationFunction {
        private static LogisticFunction instance;

        private LogisticFunction() {
        }

        public double FunctionResult(double value) {
            return 1 / (1 + Math.Exp(-value));
        }

        public double DerivateFunctionResult(double value) {
            return value * (1 - value);
        }

        public static LogisticFunction Instance {
            get {
                if (instance == null) {
                    instance = new LogisticFunction();
                }
                return instance;
            }
        }
    }
}
