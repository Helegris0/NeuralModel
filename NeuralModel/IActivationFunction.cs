using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    interface IActivationFunction {
        double FunctionResult(double value);
        double DerivateFunctionResult(double value);
    }
}
