using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {

    class Signal {

        private double signalValue;
        public bool ValueIsSet { get; private set; }

        public double SignalValue {
            get { return signalValue; }
            set {
                signalValue = value;
                ValueIsSet = true;
            }
        }
    }
}
