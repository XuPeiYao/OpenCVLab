using OpenCVLab.ConvertFlow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVLab {
    public partial class MainForm : Form {
        public string Status {
            get {
                return StatusLabel.Text;
            }
            set {
                StatusLabel.Text = value;
            }
        }
        public bool Error {
            get {
                return StatusLabel.ForeColor == Color.Red;
            }
            set {
                if (value) {
                    StatusLabel.ForeColor = Color.Red;
                } else {
                    StatusLabel.ForeColor = Color.Black;
                }
            }
        }

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            FlowTabControl.TabPages.Clear();
            Error = false;
            Application.Idle += Application_Idle_CheckError;
        }

        private void Application_Idle_CheckError(object sender, EventArgs e) {
            if (FlowTabControl.TabPages.Count == 0) return;

            Error = false;

            StepTabPage First = FlowTabControl.TabPages[0] as StepTabPage;
            if (First == null || First.PageControl.ConvertStep != null) {
                Status = "尚未輸入圖片";
                Error = true;
                return;
            }

            for (int i = 1; i < FlowTabControl.TabPages.Count; i++) {
                StepTabPage Before = FlowTabControl.TabPages[i - 1] as StepTabPage;
                StepTabPage Item = FlowTabControl.TabPages[i] as StepTabPage;
                
                if(!Before.PageControl.Attributes.Any(b=>
                    Item.PageControl.Attributes.Any(c=>c.Input == b.Output)
                )) {
                    Status = "處理流程異常";
                    Error = true;
                }
            }
            if (Error) return;


                
            Status = "就緒";
            Error = false;
        }

        public StepTabPage CreateOrigionImageTabPage() {
            StepTabPage newInstance = new StepTabPage(null);
            this.FlowTabControl.TabPages.Insert(0, newInstance);
            newInstance.AllowDrop = true;
            return newInstance;
        }
        public StepTabPage CreateTabPage<T>(int Index = 0) where T : IConvertStep {
            return CreateTabPage(Activator.CreateInstance<T>(), Index);
        }

        public StepTabPage CreateTabPage(Type Type, int Index = 0) {
            return CreateTabPage((IConvertStep)Activator.CreateInstance(Type), Index);
        }
        public StepTabPage CreateTabPage(IConvertStep ConvertStep, int Index = 0) {
            StepTabPage newInstance = new StepTabPage(ConvertStep);
            this.FlowTabControl.TabPages.Insert(Index, newInstance);
            return newInstance;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void OpenFileMenuItem_Click(object sender, EventArgs e) {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "圖片|*.jpg;*.png;*.git";
            fileDialog.Multiselect = false;
            fileDialog.FileName = "";

            if (fileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }
            if (FlowTabControl.TabPages.Count > 0 &&
                FlowTabControl.TabPages[0] != null &&
               (FlowTabControl.TabPages[0] as StepTabPage)?.PageControl.ConvertStep == null) {
                FlowTabControl.TabPages.Remove(FlowTabControl.TabPages[0]);
            }
            var newTabInstance = CreateOrigionImageTabPage();
            newTabInstance.PageControl.MainPictureBox.Image = Image.FromStream(fileDialog.OpenFile());

            FlowTabControl.SelectedIndex = 0;
        }

        private void CaptureFromWebcamMenuItem_Click(object sender, EventArgs e) {
            WebcamForm capture = new WebcamForm();
            if (capture.ShowDialog() != DialogResult.OK) {
                return;
            }
            if (FlowTabControl.TabPages.Count > 0 &&
                FlowTabControl.TabPages[0] != null &&
               (FlowTabControl.TabPages[0] as StepTabPage)?.PageControl.ConvertStep == null) {
                FlowTabControl.TabPages.Remove(FlowTabControl.TabPages[0]);
            }
            var newTabInstance = CreateOrigionImageTabPage();
            newTabInstance.PageControl.MainPictureBox.Image = capture.CaptureResult.ToBitmap();

            FlowTabControl.SelectedIndex = 0;
        }

        private void RemoveStepMenuItem_Click(object sender, EventArgs e) {
            if (FlowTabControl.TabPages.Count == 0) {
                MessageBox.Show("目前沒有步驟", "移除步驟", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show(
                $"您確定要移除步驟{FlowTabControl.SelectedIndex + 1}的{FlowTabControl.TabPages[FlowTabControl.SelectedIndex].Text}",
                "移除步驟",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (result != DialogResult.OK) {
                return;
            }
            FlowTabControl.TabPages.RemoveAt(FlowTabControl.SelectedIndex);
        }

        private void AddStepMenuItem_Click(object sender, EventArgs e) {
            var addStep = new AddStepForm();
            if (addStep.ShowDialog() != DialogResult.OK) return;

            int nowIndex = FlowTabControl.SelectedIndex;
            if (addStep.AddAfter) {
                nowIndex++;
            } else {
                nowIndex--;
                if (nowIndex < 1) nowIndex = 1;
            }

            var newInstance = CreateTabPage(addStep.SelectedType, nowIndex);
            FlowTabControl.SelectedIndex = nowIndex;
        }

        private void AboutMenuItem_Click(object sender, EventArgs e) {
            new About().ShowDialog();
        }
    }
}