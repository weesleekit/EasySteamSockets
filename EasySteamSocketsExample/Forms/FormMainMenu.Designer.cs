namespace EasySteamSocketsExample.Forms
{
    partial class FormMainMenu
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
            buttonStartServer = new Button();
            buttonStartClient = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label2 = new Label();
            textBoxPort = new TextBox();
            label1 = new Label();
            textBoxAppID = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonStartServer
            // 
            buttonStartServer.Location = new Point(6, 22);
            buttonStartServer.Name = "buttonStartServer";
            buttonStartServer.Size = new Size(86, 40);
            buttonStartServer.TabIndex = 0;
            buttonStartServer.Text = "Start Server and Client";
            buttonStartServer.UseVisualStyleBackColor = true;
            buttonStartServer.Click += ButtonStartServer_Click;
            // 
            // buttonStartClient
            // 
            buttonStartClient.Location = new Point(6, 68);
            buttonStartClient.Name = "buttonStartClient";
            buttonStartClient.Size = new Size(86, 40);
            buttonStartClient.TabIndex = 1;
            buttonStartClient.Text = "Start Client";
            buttonStartClient.UseVisualStyleBackColor = true;
            buttonStartClient.Click += ButtonStartClient_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonStartServer);
            groupBox1.Controls.Add(buttonStartClient);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(101, 119);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Launch";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxPort);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBoxAppID);
            groupBox2.Location = new Point(119, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(194, 119);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Configuration";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 54);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 4;
            label2.Text = "Port";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(63, 51);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 23);
            textBoxPort.TabIndex = 3;
            textBoxPort.Text = "25565";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 25);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "App ID";
            // 
            // textBoxAppID
            // 
            textBoxAppID.Location = new Point(63, 22);
            textBoxAppID.Name = "textBoxAppID";
            textBoxAppID.Size = new Size(100, 23);
            textBoxAppID.TabIndex = 0;
            textBoxAppID.Text = "480";
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 141);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormMainMenu";
            Text = "MainMenu";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonStartServer;
        private Button buttonStartClient;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox textBoxAppID;
        private Label label2;
        private TextBox textBoxPort;
    }
}