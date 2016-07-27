using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    public interface IConvertStep{
        IImage Convert(IImage Input, params string[] Params);
    }
}
