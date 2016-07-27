using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepIO(
        StepName = "二值化",
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>),
        ParamNames = "threshold,maxValue",
        ParamTypes = "int,int",
        ParamDefault = "128,255")]
    public class ThresholdBinaryConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            Gray thresholdValue = new Gray(int.Parse(Params.First()));
            return ((Image<Gray, byte>)Input).ThresholdBinary(thresholdValue, new Gray(255));
        }
    }
}
