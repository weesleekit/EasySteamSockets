using Steamworks.Data;
using Steamworks;
using EasySteamSockets.Classes;
using EasySteamSockets;
using EasySteamSocketsExample.Payloads.JSONPayloads;
using EasySteamSocketsExample.Payloads.BytePayloads;

namespace EasySteamSocketsExample.Forms
{
    public partial class FormServer : Form, ILogger
    {
        // Fields

        private readonly EasySocketsServer server;


        // Constructor

        public FormServer(ushort port)
        {
            InitializeComponent();

            NetAddress netAddress = NetAddress.AnyIp(port);

            server = SteamNetworkingSockets.CreateNormalSocket<EasySocketsServer>(netAddress);
            server.Logger = this;

            server.Events.Subscribe<ChatMessage>(ChatMessageReceived);
            server.Events.Subscribe<PlayerPositionUpdateMessage>(PlayerPositionUpdateMessageReceived);

            timerRecieveMessages.Enabled = true;
        }


        // Networking Events

        private void ChatMessageReceived(ChatMessage chatMessage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ChatMessageReceived(chatMessage)));
                return;
            }

            richTextBoxChat.SelectionColor = System.Drawing.Color.FromArgb(chatMessage.ColourARGB);
            richTextBoxChat.AppendText("Client:");
            richTextBoxChat.AppendText(chatMessage.Message);
            richTextBoxChat.AppendText(Environment.NewLine);
        }


        private void PlayerPositionUpdateMessageReceived(PlayerPositionUpdateMessage playerPositionUpdateMessage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => PlayerPositionUpdateMessageReceived(playerPositionUpdateMessage)));
                return;
            }
            
            int radius = 5;
            int x = (int)playerPositionUpdateMessage.X - radius;
            int y = (int)playerPositionUpdateMessage.Y - radius;

            using Graphics g = pictureBoxPlayerCanvas.CreateGraphics();
            g.DrawEllipse(Pens.Blue, x, y, 2 * radius, 2 * radius);
        }

        // UI Events

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

            Result? result = server?.SendMessageToAll(chatMessage, SendType.Reliable);

            if (result == null)
            {
                MessageBox.Show("Server is null, aborting send");
                return;
            }
            else if (result != Result.OK)
            {
                MessageBox.Show($"Error sending chat message: {result}");
                return;
            }

            richTextBoxChat.SelectionColor = System.Drawing.Color.FromArgb(chatMessage.ColourARGB);
            richTextBoxChat.AppendText("Server:");
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
            server?.Receive();
        }


        // Interface Implementation

        void ILogger.Log(string message)
        {
            textBoxLog.AppendText(Environment.NewLine + message);
        }

    }
}
