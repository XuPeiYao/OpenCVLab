using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
    public class IConvertStepMetaAttribute:Attribute {

        public string StepName { get; set; }
        public string ParamNames { get; set; }
        public string ParamTypes { get; set; }
        public string ParamDefault { get; set; }
    }
}
