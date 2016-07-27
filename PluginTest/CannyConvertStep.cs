using OpenCVLab.ConvertFlow;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginTest {
    [IConvertStepIO(
        StepName = "Canny",
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>),
        ParamNames = "thresh,threshLinking,apertureSize,l2Gradient",
        ParamTypes = "byte,byte,int,bool",
        ParamDefault = "128,255,3,false")]
    [IConvertStepIO(
        StepName = "Canny",
        Input = typeof(Image<Bgr, byte>),
        Output = typeof(Image<Gray, byte>),
        ParamNames = "thresh,threshLinking,apertureSize,l2Gradient",
        ParamTypes = "byte,byte,int,bool",
        ParamDefault = "128,255,3,false")]
    public class CannyConvertStep : IConvertStep {
        //double thresh, double threshLinking, int apertureSize, bool l2Gradient
        public IImage Convert(IImage Input, params string[] Params) {
            if (Input is Image<Gray, byte>) {
                return ((Image<Gray, byte>)Input).Canny(
                    double.Parse(Params[0]),
                    double.Parse(Params[1]),
                    int.Parse(Params[2]),
                    bool.Parse(Params[3])
                );
            }else {
                return ((Image<Bgr, byte>)Input).Canny(
                    double.Parse(Params[0]),
                    double.Parse(Params[1]),
                    int.Parse(Params[2]),
                    bool.Parse(Params[3])
                );
            }
        }
    }
}
