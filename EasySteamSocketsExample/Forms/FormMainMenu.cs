using Steamworks;
using System.Reflection;

namespace EasySteamSocketsExample.Forms
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();

            EasySteamSockets.Initialiser.Initialise(Assembly.GetExecutingAssembly());
        }


        private void ButtonStartServer_Click(object sender, EventArgs e)
        {
            SetupSteam();
            
            ushort port = Convert.ToUInt16(textBoxPort.Text);

            FormServer formServer = new(port);
            formServer.Show();

            FormClient formClient = new(port);
            formClient.Show();
        }

        private void ButtonStartClient_Click(object sender, EventArgs e)
        {
            SetupSteam();

            ushort port = Convert.ToUInt16(textBoxPort.Text);

            FormClient formClient = new(port);
            formClient.Show();
        }

        private void SetupSteam()
        {
            uint appID = Convert.ToUInt32(textBoxAppID.Text);
            SteamClient.Init(appID, true);
        }
    }
}
