using OpenCVLab.ConvertFlow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVLab {
    public partial class AddStepForm : Form {
        public static List<Type> ConvertTypes { get; set; } = new List<Type>();

        public Type SelectedType { get; set; }

        public IConvertStepTypeAttribute[] Attributes {
            get {
                if (SelectedType == null) return null;
                return SelectedType
                    .GetCustomAttributes(typeof(IConvertStepTypeAttribute), false)
                    .Select(x => (IConvertStepTypeAttribute)x)
                    .ToArray();
            }
        }

        public bool AddAfter => this.comboBox1.SelectedIndex == 1;

        public AddStepForm() {
            InitializeComponent();
        }

        private void AddStepForm_Load(object sender, EventArgs e) {
            if (ConvertTypes.Count == 0) {
                ConvertTypes.AddRange(ConvertStepHelper.GetSystemConvertStep());

                string pluginPath = Directory.GetCurrentDirectory() + "/Plugin";
                try {
                    var plugDir = new DirectoryInfo(pluginPath);
                    var files = plugDir.GetFiles().Where(x => x.Extension == ".dll").Select(x => x.FullName).ToArray();
                    foreach (var file in files) {
                        ConvertTypes.AddRange(
                            ConvertStepHelper.GetDllConvertStep(file)
                        );
                    }
                } catch { }
            }

            this.listBox1.Items.AddRange(
                ConvertTypes.Select(
                    x => ((IConvertStepMetaAttribute)x.GetCustomAttributes(typeof(IConvertStepMetaAttribute), false).First()).StepName
                ).ToArray()
            );

            this.comboBox1.SelectedIndex = 1;
            this.listBox1.SelectedIndex = 0;
        }

        private void Add_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex == -1) return;
            DialogResult = DialogResult.OK;
            SelectedType = ConvertTypes[listBox1.SelectedIndex];
            Close();
        }
        private void listBox1_DoubleClick(object sender, EventArgs e) {
            Add_Click(null, null);
        }

        private void AddStepForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (DialogResult == DialogResult.None) {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
