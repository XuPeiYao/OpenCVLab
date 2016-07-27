using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepMeta(
        StepName = "高斯模糊",
        ParamNames = "kernelWidth,kernelHeight,sigma1,sigma2",
        ParamTypes = "int(odd),int(odd),double,double",
        ParamDefault = "5,5,0,0")]
    [IConvertStepType(
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>))]
    [IConvertStepType(
        Input = typeof(Image<Bgr, byte>),
        Output = typeof(Image<Bgr, byte>))]
    public class SmoothGaussianConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            if (Input is Image<Bgr, byte>) {
                return ((Image<Bgr, byte>)Input).SmoothGaussian(int.Parse(Params[0]), int.Parse(Params[1]), double.Parse(Params[2]), double.Parse(Params[2]));
            } else {
                return ((Image<Gray, byte>)Input).SmoothGaussian(int.Parse(Params[0]), int.Parse(Params[1]), double.Parse(Params[2]), double.Parse(Params[2]));
            }
        }
    }
}
