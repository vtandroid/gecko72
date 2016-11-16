namespace TestGecko45
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new Gecko.GeckoWebBrowser();
            this.btnStart = new System.Windows.Forms.Button();
            this.clearProxy = new System.Windows.Forms.Button();
            this.btnCheckBlackList = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnSetPort = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnTestStartVip72 = new System.Windows.Forms.Button();
            this.btnClearProxy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(23, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 561);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.FrameEventsPropagateToMainWindow = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(987, 561);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.UseHttpActivityObserver = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1058, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // clearProxy
            // 
            this.clearProxy.Location = new System.Drawing.Point(1058, 52);
            this.clearProxy.Name = "clearProxy";
            this.clearProxy.Size = new System.Drawing.Size(75, 23);
            this.clearProxy.TabIndex = 2;
            this.clearProxy.Text = "Clear";
            this.clearProxy.UseVisualStyleBackColor = true;
            this.clearProxy.Click += new System.EventHandler(this.clearProxy_Click);
            // 
            // btnCheckBlackList
            // 
            this.btnCheckBlackList.Location = new System.Drawing.Point(1058, 90);
            this.btnCheckBlackList.Name = "btnCheckBlackList";
            this.btnCheckBlackList.Size = new System.Drawing.Size(75, 23);
            this.btnCheckBlackList.TabIndex = 3;
            this.btnCheckBlackList.Text = "Check BlackList";
            this.btnCheckBlackList.UseVisualStyleBackColor = true;
            this.btnCheckBlackList.Click += new System.EventHandler(this.btnCheckBlackList_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(1058, 129);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(75, 23);
            this.btnRandom.TabIndex = 4;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnSetPort
            // 
            this.btnSetPort.Location = new System.Drawing.Point(1058, 167);
            this.btnSetPort.Name = "btnSetPort";
            this.btnSetPort.Size = new System.Drawing.Size(75, 23);
            this.btnSetPort.TabIndex = 5;
            this.btnSetPort.Text = "SetPort";
            this.btnSetPort.UseVisualStyleBackColor = true;
            this.btnSetPort.Click += new System.EventHandler(this.btnSetPort_Click);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(1033, 196);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 20);
            this.txtIp.TabIndex = 6;
            this.txtIp.Text = "81.5.216";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(1033, 231);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "9192";
            // 
            // btnTestStartVip72
            // 
            this.btnTestStartVip72.Location = new System.Drawing.Point(1058, 287);
            this.btnTestStartVip72.Name = "btnTestStartVip72";
            this.btnTestStartVip72.Size = new System.Drawing.Size(75, 23);
            this.btnTestStartVip72.TabIndex = 8;
            this.btnTestStartVip72.Text = "TetStartVip72";
            this.btnTestStartVip72.UseVisualStyleBackColor = true;
            this.btnTestStartVip72.Click += new System.EventHandler(this.btnTestStartVip72_Click);
            // 
            // btnClearProxy
            // 
            this.btnClearProxy.Location = new System.Drawing.Point(1058, 333);
            this.btnClearProxy.Name = "btnClearProxy";
            this.btnClearProxy.Size = new System.Drawing.Size(75, 23);
            this.btnClearProxy.TabIndex = 9;
            this.btnClearProxy.Text = "clearProxyVip72";
            this.btnClearProxy.UseVisualStyleBackColor = true;
            this.btnClearProxy.Click += new System.EventHandler(this.btnClearProxy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 610);
            this.Controls.Add(this.btnClearProxy);
            this.Controls.Add(this.btnTestStartVip72);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.btnSetPort);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnCheckBlackList);
            this.Controls.Add(this.clearProxy);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Gecko.GeckoWebBrowser webBrowser1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button clearProxy;
        private System.Windows.Forms.Button btnCheckBlackList;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnSetPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnTestStartVip72;
        private System.Windows.Forms.Button btnClearProxy;
    }
}

