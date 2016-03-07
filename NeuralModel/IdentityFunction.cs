using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class IdentityFunction : IActivationFunction {
        private static IdentityFunction instance;

        private IdentityFunction() {
        }

        public double FunctionResult(double value) {
            return value;
        }

        public double DerivateFunctionResult(double value) {
            return 1;
        }

        public static IdentityFunction Instance {
            get {
                if (instance == null) {
                    instance = new IdentityFunction();
                }
                return instance;
            }
        }
    }
}
