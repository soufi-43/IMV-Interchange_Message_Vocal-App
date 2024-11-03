namespace IMV_Interchange_Message_Vocal_App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblConnect = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartRecord2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pcbServer = new System.Windows.Forms.PictureBox();
            this.pcbClient = new System.Windows.Forms.PictureBox();
            this.pcbPC1 = new System.Windows.Forms.PictureBox();
            this.pcbPC2 = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDispose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStopRecord2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnStopRec1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStartRec1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPC2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnect.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblConnect.Location = new System.Drawing.Point(272, 40);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(227, 23);
            this.lblConnect.TabIndex = 0;
            this.lblConnect.Text = "Connect Server-Client ";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerPort.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblServerPort.Location = new System.Drawing.Point(110, 103);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(115, 16);
            this.lblServerPort.TabIndex = 5;
            this.lblServerPort.Text = "Port Number : ";
            // 
            // lblClientPort
            // 
            this.lblClientPort.AutoSize = true;
            this.lblClientPort.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientPort.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblClientPort.Location = new System.Drawing.Point(442, 103);
            this.lblClientPort.Name = "lblClientPort";
            this.lblClientPort.Size = new System.Drawing.Size(115, 16);
            this.lblClientPort.TabIndex = 6;
            this.lblClientPort.Text = "Port Number : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(127, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "localHost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(550, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = ". ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(484, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "start rec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(115, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Playing Audio";
            // 
            // btnStartRecord2
            // 
            this.btnStartRecord2.BackColor = System.Drawing.Color.Black;
            this.btnStartRecord2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartRecord2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartRecord2.FlatAppearance.BorderSize = 0;
            this.btnStartRecord2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartRecord2.Image = ((System.Drawing.Image)(resources.GetObject("btnStartRecord2.Image")));
            this.btnStartRecord2.Location = new System.Drawing.Point(498, 277);
            this.btnStartRecord2.Name = "btnStartRecord2";
            this.btnStartRecord2.Size = new System.Drawing.Size(51, 40);
            this.btnStartRecord2.TabIndex = 13;
            this.btnStartRecord2.UseVisualStyleBackColor = false;
            this.btnStartRecord2.Click += new System.EventHandler(this.btnStartRecord_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(260, 161);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(179, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pcbServer
            // 
            this.pcbServer.BackColor = System.Drawing.Color.DodgerBlue;
            this.pcbServer.Image = global::IMV_Interchange_Message_Vocal_App.Properties.Resources.equalizer_10278_128;
            this.pcbServer.Location = new System.Drawing.Point(118, 161);
            this.pcbServer.Name = "pcbServer";
            this.pcbServer.Size = new System.Drawing.Size(107, 51);
            this.pcbServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbServer.TabIndex = 10;
            this.pcbServer.TabStop = false;
            this.pcbServer.Tag = "eq";
            // 
            // pcbClient
            // 
            this.pcbClient.BackColor = System.Drawing.Color.SteelBlue;
            this.pcbClient.Image = global::IMV_Interchange_Message_Vocal_App.Properties.Resources.public_wifi_5403_128;
            this.pcbClient.Location = new System.Drawing.Point(498, 161);
            this.pcbClient.Name = "pcbClient";
            this.pcbClient.Size = new System.Drawing.Size(59, 51);
            this.pcbClient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbClient.TabIndex = 9;
            this.pcbClient.TabStop = false;
            this.pcbClient.Tag = "wifi";
            // 
            // pcbPC1
            // 
            this.pcbPC1.BackColor = System.Drawing.Color.Transparent;
            this.pcbPC1.Image = ((System.Drawing.Image)(resources.GetObject("pcbPC1.Image")));
            this.pcbPC1.Location = new System.Drawing.Point(91, 134);
            this.pcbPC1.Name = "pcbPC1";
            this.pcbPC1.Size = new System.Drawing.Size(163, 126);
            this.pcbPC1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbPC1.TabIndex = 3;
            this.pcbPC1.TabStop = false;
            // 
            // pcbPC2
            // 
            this.pcbPC2.Image = ((System.Drawing.Image)(resources.GetObject("pcbPC2.Image")));
            this.pcbPC2.Location = new System.Drawing.Point(445, 134);
            this.pcbPC2.Name = "pcbPC2";
            this.pcbPC2.Size = new System.Drawing.Size(163, 126);
            this.pcbPC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbPC2.TabIndex = 4;
            this.pcbPC2.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Black;
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.Location = new System.Drawing.Point(225, 31);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(51, 40);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDispose
            // 
            this.btnDispose.BackColor = System.Drawing.Color.Black;
            this.btnDispose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDispose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispose.FlatAppearance.BorderSize = 0;
            this.btnDispose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispose.Image = ((System.Drawing.Image)(resources.GetObject("btnDispose.Image")));
            this.btnDispose.Location = new System.Drawing.Point(326, 287);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(51, 40);
            this.btnDispose.TabIndex = 16;
            this.btnDispose.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(316, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "dispose";
            // 
            // btnStopRecord2
            // 
            this.btnStopRecord2.BackColor = System.Drawing.Color.Black;
            this.btnStopRecord2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStopRecord2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopRecord2.FlatAppearance.BorderSize = 0;
            this.btnStopRecord2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopRecord2.Image = ((System.Drawing.Image)(resources.GetObject("btnStopRecord2.Image")));
            this.btnStopRecord2.Location = new System.Drawing.Point(572, 277);
            this.btnStopRecord2.Name = "btnStopRecord2";
            this.btnStopRecord2.Size = new System.Drawing.Size(51, 40);
            this.btnStopRecord2.TabIndex = 18;
            this.btnStopRecord2.UseVisualStyleBackColor = false;
            this.btnStopRecord2.Click += new System.EventHandler(this.btnStopRecord2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(573, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "stop rec";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(188, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "stop rec";
            // 
            // btnStopRec1
            // 
            this.btnStopRec1.BackColor = System.Drawing.Color.Black;
            this.btnStopRec1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStopRec1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopRec1.FlatAppearance.BorderSize = 0;
            this.btnStopRec1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopRec1.Image = ((System.Drawing.Image)(resources.GetObject("btnStopRec1.Image")));
            this.btnStopRec1.Location = new System.Drawing.Point(187, 287);
            this.btnStopRec1.Name = "btnStopRec1";
            this.btnStopRec1.Size = new System.Drawing.Size(51, 40);
            this.btnStopRec1.TabIndex = 22;
            this.btnStopRec1.UseVisualStyleBackColor = false;
            this.btnStopRec1.Click += new System.EventHandler(this.btnStopRec1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(99, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "start rec";
            // 
            // btnStartRec1
            // 
            this.btnStartRec1.BackColor = System.Drawing.Color.Black;
            this.btnStartRec1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartRec1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartRec1.FlatAppearance.BorderSize = 0;
            this.btnStartRec1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartRec1.Image = ((System.Drawing.Image)(resources.GetObject("btnStartRec1.Image")));
            this.btnStartRec1.Location = new System.Drawing.Point(113, 287);
            this.btnStartRec1.Name = "btnStartRec1";
            this.btnStartRec1.Size = new System.Drawing.Size(51, 40);
            this.btnStartRec1.TabIndex = 20;
            this.btnStartRec1.UseVisualStyleBackColor = false;
            this.btnStartRec1.Click += new System.EventHandler(this.btnStartRec1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(677, 435);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnStopRec1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnStartRec1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStopRecord2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDispose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartRecord2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pcbServer);
            this.Controls.Add(this.pcbClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClientPort);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.pcbPC1);
            this.Controls.Add(this.pcbPC2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoacalChat";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPC2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox pcbPC2;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblClientPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pcbPC1;
        private System.Windows.Forms.PictureBox pcbClient;
        private System.Windows.Forms.PictureBox pcbServer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnStartRecord2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStopRecord2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStopRec1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStartRec1;
    }
}

