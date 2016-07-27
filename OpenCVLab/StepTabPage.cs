using OpenCVLab.ConvertFlow;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVLab {
    public class StepTabPage : TabPage {
        public StepTabPageControl PageControl { get;private set; }
        
        public StepTabPage(IConvertStep ConvertStep = null) {
            this.PageControl = new StepTabPageControl(ConvertStep);
            this.PageControl.TabPage = this;
            this.PageControl.Dock = DockStyle.Fill;
            this.Controls.Add(this.PageControl);

            this.Text = ((IConvertStepMetaAttribute)PageControl.ConvertStep
                ?.GetType()
                ?.GetCustomAttributes(
                    typeof(IConvertStepMetaAttribute),false
                )?.FirstOrDefault())?.StepName;
            if (ConvertStep == null) this.Text = "原始圖片";
        }
    }
}
