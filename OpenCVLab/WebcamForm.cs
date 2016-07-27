using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVLab {
    public partial class WebcamForm : Form {
        //參考: https://gnehcic.azurewebsites.net/emgucv%E5%8F%96%E5%BE%97%E6%94%9D%E5%BD%B1%E6%A9%9F%E5%BD%B1%E5%83%8F/
        public Capture Webcam { get; set; }
        public Image<Bgr, byte> CaptureResult { get; set; }
        public WebcamForm() {
            InitializeComponent();
        }

        private void WebcamForm_Load(object sender, EventArgs e) {
            Webcam = new Capture(0);
            Webcam.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);
            Webcam.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);
            
            //建立系統閒置處理程序
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e) {
            try {
                //取得網路攝影機的影像
                CaptureResult = Webcam.QueryFrame().ToImage<Bgr, byte>();
                //顯示影像到PictureBox上
                CapturePictureBox.Image = CaptureResult.Bitmap;
                if (GC.GetTotalMemory(false) > 1024 * 1024 * 100) {
                    GC.Collect();
                }
            }catch { }
        }

        private void CaptureButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void WebcamForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (DialogResult == DialogResult.None) {
                DialogResult = DialogResult.Cancel;
            }
            Application.Idle -= Application_Idle;
            GC.Collect();
        }
    }
}
