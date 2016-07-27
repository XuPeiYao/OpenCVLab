using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class IConvertStepTypeAttribute: Attribute {
        public Type Input { get; set; }
        public Type Output { get; set; }
    }
}
