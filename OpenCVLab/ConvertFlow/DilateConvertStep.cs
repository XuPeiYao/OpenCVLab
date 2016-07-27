using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepMeta(
        StepName = "擴張處理",
        ParamNames = "iterations",
        ParamTypes = "int",
        ParamDefault = "1")]
    [IConvertStepType(
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>))]
    public class DilateConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            return ((Image<Gray, byte>)Input).Dilate(int.Parse(Params.First()));
        }
    }
}
