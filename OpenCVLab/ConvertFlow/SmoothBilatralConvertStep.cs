using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepMeta(
        StepName = "Bilatral模糊",
        ParamNames = "kernelSize,colorSigma,spaceSigma",
        ParamTypes = "int,int,int",
        ParamDefault = "128,128,128")]
    [IConvertStepType(
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>))]
    [IConvertStepType(
        Input = typeof(Image<Bgr, byte>),
        Output = typeof(Image<Bgr, byte>))]
    public class SmoothBilatralConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            if (Input is Image<Bgr, byte>) {
                return ((Image<Bgr, byte>)Input).SmoothBilatral(int.Parse(Params[0]), int.Parse(Params[1]), int.Parse(Params[2]));
            } else {
                return ((Image<Gray, byte>)Input).SmoothBilatral(int.Parse(Params[0]), int.Parse(Params[1]), int.Parse(Params[2]));
            }
        }
    }
}
