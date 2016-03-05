using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    class Signal {
        public double SignalValue { get { return SignalValue; } set { SignalValue = value; ValueIsSet = true; } }
        public bool ValueIsSet { get; private set; }
    }
}
