using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class NetworkProperties {
        public int NumberOfInputs { get; }

        public NetworkProperties(int numberOfInputs) {
            NumberOfInputs = numberOfInputs;
        }
    }
}
