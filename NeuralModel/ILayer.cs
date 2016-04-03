using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralModel {
    interface ILayer {
        int NumberOfCells();
        void SetDefaultWeights();
        void SetInputs(double[] inputs);
        double[] Outputs();
    }
}
