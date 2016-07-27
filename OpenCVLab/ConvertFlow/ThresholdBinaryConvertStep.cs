using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepMeta(
        StepName = "二值化",
        ParamNames = "threshold,maxValue",
        ParamTypes = "int,int",
        ParamDefault = "128,255")]
    [IConvertStepType(
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>))]
    public class ThresholdBinaryConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            Gray thresholdValue = new Gray(int.Parse(Params.First()));
            return ((Image<Gray, byte>)Input).ThresholdBinary(thresholdValue, new Gray(255));
        }
    }
}
