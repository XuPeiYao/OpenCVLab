using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepIO(
        StepName = "侵蝕處理",
        ParamNames = "iterations",
        ParamTypes = "int",
        ParamDefault = "1",
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>))]
    public class ErodeConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            return ((Image<Gray, byte>)Input).Erode(int.Parse(Params.First()));
        }
    }
}
