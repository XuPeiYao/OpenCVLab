using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepMeta(
        StepName = "反像轉換")]
    [IConvertStepType(
        Input = typeof(Image<Gray, byte>),
        Output = typeof(Image<Gray, byte>))]
    [IConvertStepType(
        Input = typeof(Image<Bgr, byte>),
        Output = typeof(Image<Bgr, byte>))]
    public class NotConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            if (Input is Image<Bgr, byte>) {
                return ((Image<Bgr, byte>)Input).Not();
            }else {
                return ((Image<Gray, byte>)Input).Not();
            }
        }
    }
}
