namespace EasySteamSocketsExample.Forms
{
    partial class FormClient
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
            components = new System.ComponentModel.Container();
            buttonJoin = new Button();
            textBoxIP = new TextBox();
            textBoxLog = new TextBox();
            textBoxChatMessage = new TextBox();
            groupBoxChat = new GroupBox();
            buttonChatColour = new Button();
            richTextBoxChat = new RichTextBox();
            colorDialogChat = new ColorDialog();
            groupBox2 = new GroupBox();
            timerRecieveMessages = new System.Windows.Forms.Timer(components);
            pictureBoxPlayerCanvas = new PictureBox();
            groupBoxPlayerCanvas = new GroupBox();
            groupBoxChat.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerCanvas).BeginInit();
            groupBoxPlayerCanvas.SuspendLayout();
            SuspendLayout();
            // 
            // buttonJoin
            // 
            buttonJoin.Location = new Point(6, 60);
            buttonJoin.Name = "buttonJoin";
            buttonJoin.Size = new Size(86, 23);
            buttonJoin.TabIndex = 0;
            buttonJoin.Text = "Join";
            buttonJoin.UseVisualStyleBackColor = true;
            buttonJoin.Click += ButtonJoin_Click;
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(6, 33);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(86, 23);
            textBoxIP.TabIndex = 1;
            textBoxIP.Text = "127.0.0.1";
            // 
            // textBoxLog
            // 
            textBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLog.Location = new Point(12, 388);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(460, 161);
            textBoxLog.TabIndex = 2;
            // 
            // textBoxChatMessage
            // 
            textBoxChatMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxChatMessage.Location = new Point(6, 144);
            textBoxChatMessage.Name = "textBoxChatMessage";
            textBoxChatMessage.Size = new Size(271, 23);
            textBoxChatMessage.TabIndex = 4;
            textBoxChatMessage.Text = "hello world";
            textBoxChatMessage.KeyDown += TextBoxChatMessage_KeyDown;
            // 
            // groupBoxChat
            // 
            groupBoxChat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxChat.Controls.Add(buttonChatColour);
            groupBoxChat.Controls.Add(richTextBoxChat);
            groupBoxChat.Controls.Add(textBoxChatMessage);
            groupBoxChat.Enabled = false;
            groupBoxChat.Location = new Point(131, 12);
            groupBoxChat.Name = "groupBoxChat";
            groupBoxChat.Size = new Size(341, 173);
            groupBoxChat.TabIndex = 8;
            groupBoxChat.TabStop = false;
            groupBoxChat.Text = "Chat";
            // 
            // buttonChatColour
            // 
            buttonChatColour.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonChatColour.BackColor = Color.Blue;
            buttonChatColour.ForeColor = Color.White;
            buttonChatColour.Location = new Point(283, 144);
            buttonChatColour.Name = "buttonChatColour";
            buttonChatColour.Size = new Size(52, 23);
            buttonChatColour.TabIndex = 5;
            buttonChatColour.Text = "Colour";
            buttonChatColour.UseVisualStyleBackColor = false;
            buttonChatColour.Click += ButtonChatColour_Click;
            // 
            // richTextBoxChat
            // 
            richTextBoxChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxChat.Location = new Point(6, 22);
            richTextBoxChat.Name = "richTextBoxChat";
            richTextBoxChat.Size = new Size(329, 116);
            richTextBoxChat.TabIndex = 0;
            richTextBoxChat.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonJoin);
            groupBox2.Controls.Add(textBoxIP);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(101, 173);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Server Connection";
            // 
            // timerRecieveMessages
            // 
            timerRecieveMessages.Tick += TimerRecieveMessages_Tick;
            // 
            // pictureBoxPlayerCanvas
            // 
            pictureBoxPlayerCanvas.Dock = DockStyle.Fill;
            pictureBoxPlayerCanvas.Location = new Point(3, 19);
            pictureBoxPlayerCanvas.Name = "pictureBoxPlayerCanvas";
            pictureBoxPlayerCanvas.Size = new Size(454, 169);
            pictureBoxPlayerCanvas.TabIndex = 10;
            pictureBoxPlayerCanvas.TabStop = false;
            pictureBoxPlayerCanvas.MouseClick += PictureBoxPlayerCanvas_MouseClick;
            // 
            // groupBoxPlayerCanvas
            // 
            groupBoxPlayerCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPlayerCanvas.Controls.Add(pictureBoxPlayerCanvas);
            groupBoxPlayerCanvas.Enabled = false;
            groupBoxPlayerCanvas.Location = new Point(12, 191);
            groupBoxPlayerCanvas.Name = "groupBoxPlayerCanvas";
            groupBoxPlayerCanvas.Size = new Size(460, 191);
            groupBoxPlayerCanvas.TabIndex = 11;
            groupBoxPlayerCanvas.TabStop = false;
            groupBoxPlayerCanvas.Text = "Player Canvas";
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 561);
            Controls.Add(groupBoxPlayerCanvas);
            Controls.Add(textBoxLog);
            Controls.Add(groupBox2);
            Controls.Add(groupBoxChat);
            Name = "FormClient";
            Text = "FormClient";
            groupBoxChat.ResumeLayout(false);
            groupBoxChat.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerCanvas).EndInit();
            groupBoxPlayerCanvas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonJoin;
        private TextBox textBoxIP;
        private TextBox textBoxLog;
        private TextBox textBoxChatMessage;
        private GroupBox groupBoxChat;
        private RichTextBox richTextBoxChat;
        private ColorDialog colorDialogChat;
        private Button buttonChatColour;
        private GroupBox groupBox2;
        private System.Windows.Forms.Timer timerRecieveMessages;
        private PictureBox pictureBoxPlayerCanvas;
        private GroupBox groupBoxPlayerCanvas;
    }
}