using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OpenCVLab.ConvertFlow {
    [IConvertStepIO(
        StepName = "轉換為灰階",
        Input = typeof(Image<Bgr, byte>), 
        Output = typeof(Image<Gray, byte>))]
    public class BgrToGrayConvertStep : IConvertStep {
        public IImage Convert(IImage Input, params string[] Params) {
            return new Image<Gray, byte>(((Image<Bgr, byte>)Input).ToBitmap());
        }
    }
}
