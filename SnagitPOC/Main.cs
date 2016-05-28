using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SNAGITLib;


namespace SnagitPOC
{
    public partial class Main : Form
    {
        public readonly ImageCaptureClass SnagImg;
        private string _lastSavedFolder;
        //Update capture status text box
        public delegate void UpdateStatusTextCallback(string errorText);
        private void UpdateStatusText(string errorText)
        {
            //StatusTextBox.Text = errorText;
        }

        //Event handler for errors from Snagit
        public void ErrorTextEventListener(snagError errorNum)
        {
            var strErrMsg = errorNum == snagError.serrNone ? "None" : "Snagit error: " + errorNum;
            MessageBox.Show(strErrMsg);
            //StatusTextBox.Invoke(new UpdateStatusTextCallback(UpdateStatusText), new object[]
            //                                                                 {
            //                                                                 strErrMsg
            //                                                                 });
        }

        //Event handler for Snagit capture state changes
        public void CaptureStateEventListener(snagCaptureState state)
        {
            //OnStateChange
            if (state == snagCaptureState.scsIdle)
            {
                //When Snagit is idle we know that we are done capturing.
                //Now is a good time to stop listening to events.
                UnhookSnagitEvents();
            }
            MessageBox.Show(state.ToString());
            //StatusTextBox.Invoke(new UpdateStatusTextCallback(UpdateStatusText), new object[]
            //                                                                 {
            //                                                                 state.ToString()
            //                                                                 });
            //if (CaptureResultsChkBx.Checked)
            //{
            //    var thread = new Thread(DisplayCaptureSelectionResults);
            //    thread.Start();
            //}
        }

        //Event handler for when Snagit completes writing a capture to file
        public void FileWriteEventListener(string fileWritten)
        {
            var strStatusMsg = "Capture saved to file " + fileWritten;
            MessageBox.Show(strStatusMsg);
            //StatusTextBox.Invoke(new UpdateStatusTextCallback(UpdateStatusText), new object[]
            //                                                                 {
            //                                                                 strStatusMsg
            //                                                                 });
        }

        public Main()
        {
            InitializeComponent();
            SnagImg = new ImageCaptureClass();
        }

        private void btnCapture1_Click(object sender, EventArgs e)
        {
            SetInputOptions();
            SetOutputOptions();

            //Call the capture action on a separate thread so as not to lock up the UI
            var startThread = new Thread(StartThreadWorker);
            startThread.Start();

        }

        private void StartThreadWorker()
        {
            HookupSnagitEvents();
            try
            {
                SnagImg.Capture();
            }
            catch
            {
                var strErrorMessage = "Snagit error: " + SnagImg.LastError;
                MessageBox.Show(strErrorMessage);
            }
        }


        public void SetInputOptions()
        {
            SnagImg.Input = snagImageInput.siiWindow;
            SnagImg.AutoScrollOptions.AutoScrollMethod = snagAutoScrollMethod.sasmVertical;
            SnagImg.AutoScrollOptions.StartingPosition = snagAutoScrollStartingPosition.sasspTop;
            SnagImg.InputWindowOptions.SelectionMethod = snagWindowSelectionMethod.swsmActive;
            SnagImg.DelayOptions.EnableDelayedCapture = true;
            SnagImg.DelayOptions.EnableCountdownWindow = true;
            SnagImg.DelayOptions.DelaySeconds = 5;
            SnagImg.AutoScrollOptions.ForegroundScrollingWindow = false;

            //This used to pertain to the fastest scrolling method where we simply resize the window
            //and take the capture (same as with extended window capture). Now it means that we use
            //vision technology to perform scrolling captures. Setting this option to "false" will
            //force Snagit to use the older extended window scrolling technology.
            ((IAutoScrollOptions2)(SnagImg.AutoScrollOptions)).FastestScrollingMethod = true;
        }

        public void SetOutputOptions()
        {
            SnagImg.Output = snagImageOutput.sioFile;
            SnagImg.OutputImageFile.FileNamingMethod = snagOuputFileNamingMethod.sofnmFixed;
            SnagImg.OutputImageFile.FileType = snagImageFileType.siftPNG;
            SnagImg.OutputImageFile.Quality = 90;
            SnagImg.OutputImageFile.ColorDepth = snagImageColorDepth.sicd24Bit;
            SnagImg.OutputImageFile.FileSubType = snagImageFileSubType.sifstJTIF_444;
            SnagImg.OutputImageFile.Directory = @"c:\working";
            SnagImg.OutputImageFile.Filename = "SnagitPOC_" + DateTime.Now.Year.ToString() +
                                               DateTime.Now.Month.ToString()
                                               + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                               DateTime.Now.Second.ToString();

        }

        #region Hook/Unhook Snagit Event Handlers
        private void HookupSnagitEvents()
        {
            //Hook up event handlers
            SnagImg.OnError += ErrorTextEventListener;
            SnagImg.OnStateChange += CaptureStateEventListener;
            SnagImg.OnFileWritten += FileWriteEventListener;
        }

        private void UnhookSnagitEvents()
        {
            //Remove event handlers when finished
            SnagImg.OnError -= ErrorTextEventListener;
            SnagImg.OnStateChange -= CaptureStateEventListener;
            SnagImg.OnFileWritten -= FileWriteEventListener;
        }
        #endregion






    }  // class
} // namespae
