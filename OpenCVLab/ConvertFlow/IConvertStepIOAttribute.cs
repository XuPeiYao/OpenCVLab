using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVLab.ConvertFlow {
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class IConvertStepIOAttribute: Attribute {
        public Type Input { get; set; }
        public Type Output { get; set; }

        public string StepName { get; set; }
        public string ParamNames { get; set; }
        public string ParamTypes { get; set; }
        public string ParamDefault { get; set; }
    }
}
