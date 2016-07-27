using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepMeta(
        StepName = "平滑模糊(Smooth Blur)",
        ParamNames = "width,height,scale",
        ParamTypes = "int,int,bool",
        ParamDefault = "5,5,true")]
    [IConvertStepType(
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>))]
    [IConvertStepType(
        Input = typeof(Image<Bgr, byte>),
        Output = typeof(Image<Bgr, byte>))]
    public class SmoothBlurConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            if (Input is Image<Bgr, byte>) {
                return ((Image<Bgr, byte>)Input).SmoothBlur(int.Parse(Params[0]), int.Parse(Params[1]), bool.Parse(Params[2]));
            } else {
                return ((Image<Gray, byte>)Input).SmoothBlur(int.Parse(Params[0]), int.Parse(Params[1]), bool.Parse(Params[2]));
            }
        }
    }
}
