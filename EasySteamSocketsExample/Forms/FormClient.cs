using Steamworks.Data;
using Steamworks;
using EasySteamSockets;
using EasySteamSockets.Classes;
using EasySteamSocketsExample.Payloads.JSONPayloads;
using EasySteamSocketsExample.Payloads.BytePayloads;

namespace EasySteamSocketsExample.Forms
{
    public partial class FormClient : Form, ILogger
    {
        // Fields

        private EasySocketsClient? client;

        private readonly ushort port;


        // Constructor

        public FormClient(ushort port)
        {
            InitializeComponent();
            this.port = port;
        }


        // Networking Events

        private void ChatMessageReceived(ChatMessage chatMessage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateChat(chatMessage)));
            }
            else
            {
                UpdateChat(chatMessage);
            }
        }

        private void UpdateChat(ChatMessage chatMessage)
        {
            richTextBoxChat.SelectionColor = System.Drawing.Color.FromArgb(chatMessage.ColourARGB);
            richTextBoxChat.AppendText("Server:");
            richTextBoxChat.AppendText(chatMessage.Message);
            richTextBoxChat.AppendText(Environment.NewLine);
        }


        // UI Events

        private void ButtonJoin_Click(object sender, EventArgs e)
        {
            NetAddress netAddress = NetAddress.From(textBoxIP.Text, port);

            client = SteamNetworkingSockets.ConnectNormal<EasySocketsClient>(netAddress);
            client.Logger = this;

            client?.Events.Subscribe<ChatMessage>(ChatMessageReceived);

            timerRecieveMessages.Enabled = true;
            groupBoxPlayerCanvas.Enabled = true;
            groupBoxChat.Enabled = true;
        }

        private void TextBoxChatMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.Handled = true;

            ChatMessage chatMessage = new()
            {
                Message = textBoxChatMessage.Text,
                ColourARGB = buttonChatColour.BackColor.ToArgb(),
            };

            Result? result = client?.SendMessage(chatMessage, SendType.Reliable);

            if (result == null)
            {
                MessageBox.Show("Client is null, aborting send");
                return;
            }
            else if (result != Result.OK)
            {
                MessageBox.Show($"Error sending chat message: {result}");
                return;
            }

            richTextBoxChat.SelectionColor = System.Drawing.Color.FromArgb(chatMessage.ColourARGB);
            richTextBoxChat.AppendText("Client:");
            richTextBoxChat.AppendText(textBoxChatMessage.Text);
            richTextBoxChat.AppendText(Environment.NewLine);
            textBoxChatMessage.Text = string.Empty;
        }

        private void ButtonChatColour_Click(object sender, EventArgs e)
        {
            if (colorDialogChat.ShowDialog() == DialogResult.OK)
            {
                buttonChatColour.BackColor = colorDialogChat.Color;
            }
        }

        private void TimerRecieveMessages_Tick(object sender, EventArgs e)
        {
            client?.Receive();
        }

        private void PictureBoxPlayerCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            // Add logic to draw a small circle at the clicked position
            int radius = 5;
            int x = e.X - radius;
            int y = e.Y - radius;

            using (Graphics g = pictureBoxPlayerCanvas.CreateGraphics())
            {
                g.DrawEllipse(Pens.Blue, x, y, 2 * radius, 2 * radius);
            }

            PlayerPositionUpdateMessage playerPositionUpdateMessage = new()
            {
                Id = 123,
                X = x,
                Y = y,
            };

            client?.SendMessage(playerPositionUpdateMessage, SendType.Reliable);
        }


        // Interface Implementation

        void ILogger.Log(string message)
        {
            textBoxLog.AppendText(Environment.NewLine + message);
        }
    }
}
