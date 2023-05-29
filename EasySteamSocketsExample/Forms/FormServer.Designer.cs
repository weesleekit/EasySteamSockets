namespace EasySteamSocketsExample.Forms
{
    partial class FormServer
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
            timerRecieveMessages = new System.Windows.Forms.Timer(components);
            groupBox1 = new GroupBox();
            buttonChatColour = new Button();
            richTextBoxChat = new RichTextBox();
            textBoxChatMessage = new TextBox();
            colorDialogChat = new ColorDialog();
            groupBox3 = new GroupBox();
            pictureBoxPlayerCanvas = new PictureBox();
            textBoxLog = new TextBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerCanvas).BeginInit();
            SuspendLayout();
            // 
            // timerRecieveMessages
            // 
            timerRecieveMessages.Tick += TimerRecieveMessages_Tick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonChatColour);
            groupBox1.Controls.Add(richTextBoxChat);
            groupBox1.Controls.Add(textBoxChatMessage);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 173);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chat";
            // 
            // buttonChatColour
            // 
            buttonChatColour.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonChatColour.BackColor = Color.Red;
            buttonChatColour.ForeColor = Color.White;
            buttonChatColour.Location = new Point(402, 144);
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
            richTextBoxChat.Size = new Size(448, 116);
            richTextBoxChat.TabIndex = 0;
            richTextBoxChat.Text = "";
            // 
            // textBoxChatMessage
            // 
            textBoxChatMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxChatMessage.Location = new Point(6, 144);
            textBoxChatMessage.Name = "textBoxChatMessage";
            textBoxChatMessage.Size = new Size(390, 23);
            textBoxChatMessage.TabIndex = 4;
            textBoxChatMessage.Text = "hello world";
            textBoxChatMessage.KeyDown += TextBoxChatMessage_KeyDown;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(pictureBoxPlayerCanvas);
            groupBox3.Location = new Point(12, 191);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(460, 191);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Player Canvas";
            // 
            // pictureBoxPlayerCanvas
            // 
            pictureBoxPlayerCanvas.Dock = DockStyle.Fill;
            pictureBoxPlayerCanvas.Location = new Point(3, 19);
            pictureBoxPlayerCanvas.Name = "pictureBoxPlayerCanvas";
            pictureBoxPlayerCanvas.Size = new Size(454, 169);
            pictureBoxPlayerCanvas.TabIndex = 10;
            pictureBoxPlayerCanvas.TabStop = false;
            // 
            // textBoxLog
            // 
            textBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxLog.Location = new Point(12, 388);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.Size = new Size(460, 161);
            textBoxLog.TabIndex = 12;
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 561);
            Controls.Add(groupBox3);
            Controls.Add(textBoxLog);
            Controls.Add(groupBox1);
            Name = "FormServer";
            Text = "FormServer";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayerCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timerRecieveMessages;
        private GroupBox groupBox1;
        private Button buttonChatColour;
        private RichTextBox richTextBoxChat;
        private TextBox textBoxChatMessage;
        private ColorDialog colorDialogChat;
        private GroupBox groupBox3;
        private PictureBox pictureBoxPlayerCanvas;
        private TextBox textBoxLog;
    }
}