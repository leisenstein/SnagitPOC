using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SNAGITLib;


namespace SnagitPOC
{
    public partial class Main : Form
    {
        public readonly ImageCaptureClass SnagImg;
        private string _lastSavedFolder;

        public Main()
        {
            InitializeComponent();
            SnagImg = new ImageCaptureClass();
        }

        private void btnCapture1_Click(object sender, EventArgs e)
        {
            SnagImg.Input = snagImageInput.siiWindow;
            SnagImg.AutoScrollOptions.AutoScrollMethod = snagAutoScrollMethod.sasmBoth;
            SnagImg.AutoScrollOptions.Delay = 100;

            SnagImg.AutoScrollOptions.StartingPosition = snagAutoScrollStartingPosition.sasspTop;
            




            SnagImg.Output = snagImageOutput.sioClipboard;
            SnagImg.OutputImageFile.FileType = snagImageFileType.siftPNG;
            SnagImg.OutputImageFile.Quality = 90;
            SnagImg.OutputImageFile.ColorDepth = snagImageColorDepth.sicd24Bit;
            SnagImg.OutputImageFile.FileSubType = snagImageFileSubType.sifstJTIF_444;




















            try
            {
                SnagImg.Capture();
            }
            catch
            {
                System.Console.WriteLine(SnagImg.LastError.ToString());
            }

        }

        private void btnCapture2_Click(object sender, EventArgs e)
        {

        }

        private void btnCapture3_Click(object sender, EventArgs e)
        {

        }
    }
}
