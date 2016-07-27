using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCVLab.ConvertFlow;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OpenCVLab {
    public partial class StepTabPageControl : UserControl {
        public StepTabPage TabPage { get; internal set; }
        public IConvertStep ConvertStep { get; private set; }
        public TextBox[] InputTextBoxs { get; private set; } = new TextBox[0];
        public IConvertStepIOAttribute[] Attributes {
            get {
                if (ConvertStep == null)
                    return new IConvertStepIOAttribute[] {
                        new IConvertStepIOAttribute() {
                            StepName = "原始圖檔",
                            Output = typeof(Image<Bgr,byte>)
                        }
                    };
                return ConvertStep.GetType()
                    .GetCustomAttributes(typeof(IConvertStepIOAttribute), false)
                    .Select(x => (IConvertStepIOAttribute)x)
                    .ToArray();
            }
        }
        public StepTabPageControl(IConvertStep ConvertStep = null) {
            this.ConvertStep = ConvertStep;

            InitializeComponent();
            InputType.Items.AddRange(Attributes.Select(x => x.Input?.FullName).Where(x => x != null).ToArray());
            OutputType.Items.AddRange(Attributes.Select(x => x.Output?.FullName).Where(x => x != null).ToArray());

            if (Attributes.First().ParamNames != null) {
                var Names = Attributes.First().ParamNames.Split(',');
                var Types = Attributes.First().ParamTypes.Split(',');
                var Defaults = Attributes.First().ParamDefault.Split(',');

                InputTextBoxs = new TextBox[Names.Length];
                for (int i = Names.Length - 1; i >= 0; i--) {
                    PropertyPanel.Controls.Add(InputTextBoxs[i] = new TextBox() {
                        Text = Defaults[i],
                        Dock = DockStyle.Top
                    });

                    PropertyPanel.Controls.Add(new Label() {
                        Text = Names[i] + "(" + Types[i] + ")",
                        Dock = DockStyle.Top,
                        Font = new Font("Arial", 12)
                    });
                }
            }
        }

        public Bitmap GetBitmap() {
            return new Bitmap(MainPictureBox.Image);
        }
        
        public IImage GetBeforeImage() {
            StepTabPage tab = (StepTabPage)this.TabPage;
            TabControl tabControl = (TabControl)tab.Parent;
            var index = tabControl.TabPages.IndexOf(tab) - 1;
            if(index == -1) return new Image<Bgr, byte>(new Bitmap(MainPictureBox.Image));
            return ((StepTabPage)tabControl.TabPages[index]).PageControl.GetResultImage();
        }

        public IImage GetResultImage() {
            if (ConvertStep == null) return new Image<Bgr, byte>(new Bitmap(MainPictureBox.Image));
            var result = ConvertStep.Convert(GetBeforeImage(), InputTextBoxs.Select(x => x.Text).ToArray());
            MainPictureBox.Image = result.Bitmap;
            return result;
        }

        private void BeforeButton_Click(object sender, EventArgs e) {
            StepTabPage tab = (StepTabPage)this.TabPage;
            TabControl tabControl = (TabControl)tab.Parent;
            int before = tabControl.TabPages.IndexOf(tab) - 1;
            if (before < 0) before = 0;
            tabControl.TabPages.Remove(tab);
            tabControl.TabPages.Insert(before, tab);
            tabControl.SelectedIndex = before;
        }
        private void CloseButton_Click(object sender, EventArgs e) {
            StepTabPage tab = (StepTabPage)this.TabPage;
            TabControl tabControl = (TabControl)tab.Parent;
            tabControl.TabPages.Remove(tab);
        }
        private void AfterButton_Click(object sender, EventArgs e) {
            StepTabPage tab = (StepTabPage)this.TabPage;
            TabControl tabControl = (TabControl)tab.Parent;
            int after = tabControl.TabPages.IndexOf(tab) + 1;
            if (after >= tabControl.TabPages.Count) after = tabControl.TabPages.Count - 1;
            tabControl.TabPages.Remove(tab);
            tabControl.TabPages.Insert(after, tab);
            tabControl.SelectedIndex = after;
        }

        private void InputType_SelectedIndexChanged(object sender, EventArgs e) {
            OutputType.SelectedIndex = InputType.SelectedIndex;
        }

        private void OutputType_SelectedIndexChanged(object sender, EventArgs e) {
            InputType.SelectedIndex = OutputType.SelectedIndex;
        }
        
        public void Run() {
            this.MainPictureBox.Image =  GetResultImage().Bitmap;
        }
        private void button1_Click(object sender, EventArgs e) {
            if(ConvertStep == null) {
                MessageBox.Show("原始圖片無法進行運算", "無法執行", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (((MainForm)this.FindForm()).Error) {
                MessageBox.Show("流程中有錯誤，請檢查流程中的型別是否正確", "無法執行", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Run();
        }
    }
}
