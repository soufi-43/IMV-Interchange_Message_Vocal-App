using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMV_Interchange_Message_Vocal_App.Properties;
using ServerSocket;

using PortNumber = ServerSocket.ServerSocket.enPortNum;






namespace IMV_Interchange_Message_Vocal_App
{
    public partial class IMVForm : Form
    {


        Thread t;
        public IMVForm()
        {
            InitializeComponent();


        }
        private void OnRecordingServerStopped()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnRecordingServerStopped));
            }
            else
            {
                // Now on the UI thread; safe to update controls
                btnStartRecord2.Enabled = false;
                btnStopRecord2.Enabled = false;
                btnStartRec1.Enabled = true;
                //btnStopRec1.Enabled = true;
                lblServerPort.Text = "Audio playback complete.";
            }
        }

        private void OnRecordingClientStopped()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(OnRecordingClientStopped));
            }
            else
            {
                // Now on the UI thread; safe to update controls
                btnStartRec1.Enabled = false;
                btnStopRec1.Enabled = false;
                btnStartRecord2.Enabled = true;
                //btnStopRec1.Enabled = true;
                lblServerPort.Text = "Audio playback complete.";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            pcbServer.Hide();
            pcbClient.Hide();
            btnStartRecord2.Enabled = false;
            btnStopRecord2.Enabled = false;
            btnStartRec1.Enabled = false;
            btnStopRec1.Enabled = false;





        }


        private void HandleShowLbales()
        {
            lblServerPort.Text = "Waiting for a connection...";
            pcbServer.Hide();
            pcbClient.Show();
        }
        private void StartListening(PortNumber port)
        {
            //await Task.Run(()=>ServerSocket.ServerSocket.StartServerAudio(PortNumber)); 

            t = new Thread(() => ServerSocket.ServerSocket.StartServerAudio(port));

            t.Start();
            //t.Join();
        }
       


        private void LunchPicBox()
        {
            pcbServer.Image = Resources.equalizer_10278_128;
            pcbClient.Image = Resources.public_wifi_5403_128;
        }
        private void btnStartRecord_Click(object sender, EventArgs e)
        {
            LunchPicBox();
            StartListening(PortNumber.server);

            lblServerPort.Text = "start recording ";
            lblClientPort.Text = "Listening ...";

            btnStartRecord2.Enabled = false;
            btnStopRecord2.Enabled = true;

            ClientSocket.ClientSocket.StartRecordAudio();

        }

        private void btnStopRecord2_Click(object sender, EventArgs e)
        {
            lblServerPort.Text = "Playing Audio ";

            pcbServer.Show();

            // Wait for the audio to be sent and played
            ClientSocket.ClientSocket.StopRecordAndSendAudio((int)PortNumber.server);

            ServerSocket.ServerSocket.RecordingStopped += OnRecordingServerStopped;


        }

        private void switchPicBox()
        {
            if (pcbServer.Tag.ToString() == "eq")

            {
                pcbServer.Image = Resources.public_wifi_5403_128;
                //pcbServer.Tag = "wifi"; 

            }
            if (pcbServer.Tag.ToString() == "wifi")

            {
                pcbServer.Image = Resources.equalizer_10278_128;
                //pcbServer.Tag = "eq";


            }
            if (pcbClient.Tag.ToString() == "wifi")

            {
                pcbClient.Image = Resources.equalizer_10278_128;
                //pcbClient.Tag = "eq";


            }
            if (pcbClient.Tag.ToString() == "eq")

            {
                pcbClient.Image = Resources.public_wifi_5403_128;
                //pcbClient.Tag = "wifi";


            }




        }
        private void btnStartRec1_Click(object sender, EventArgs e)
        {


            //MessageBox.Show(pcbServer.Tag.ToString()); 
            //pcbServer.Hide();
            switchPicBox();

            lblServerPort.Text = "Listening ...";
            lblClientPort.Text = "start recording ";
            StartListening(PortNumber.client);
            btnStopRec1.Enabled = true;




            // start recording 
            btnStartRec1.Enabled = false;
            btnStopRec1.Enabled = true;


            //pcbClient.Show(); 

            ClientSocket.ClientSocket.StartRecordAudio();


        }

        private void btnStopRec1_Click(object sender, EventArgs e)
        {
            //lblServerPort.Text = "Playing Audio ";
            lblClientPort.Text = "playing audio ";
            pcbServer.Show();

            // Wait for the audio to be sent and played
            ClientSocket.ClientSocket.StopRecordAndSendAudio((int)PortNumber.client);

            ServerSocket.ServerSocket.RecordingStopped += OnRecordingClientStopped;

        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            btnStartRecord2.Enabled = true;
            //btnStopRecord2.Enabled = false;
            HandleShowLbales();

        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            t.Abort();
            MessageBox.Show("you just disconnect you have to connect again "); 
        }
    }
}