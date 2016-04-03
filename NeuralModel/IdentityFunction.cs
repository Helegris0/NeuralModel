using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    class IdentityFunction : IActivationFunction {

        public double FunctionResult(double value) {
            return value;
        }

        public double DerivateFunctionResult(double value) {
            return 1;
        }
    }
}
