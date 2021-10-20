using ServiceClientClassLibrary;
using ServiceClientClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiningClient
{
    public partial class MainForm : Form
    {
        public Game CurrentGame { get; set; }
        public Team _ourTeam { get; set; }
        internal ServiceClient ServiceClient { get; set; }
        AdminServiceClient adminClient;
        private Uri _baseUri = new Uri("https://localhost:44351/api/");

        public MainForm()
        {
            InitializeComponent();
             adminClient = new (_baseUri);
            adminClient.CreateGame("Our game", 12, 8);
            _ourTeam = new Team() {Name = "Our team", KnownQuadrants = new List<Quadrant>() { new Quadrant() { X = 2, Y = 7, Content=10} ,
            new Quadrant() { X = 11, Y = 5, Content=50},
            new Quadrant() { X = 8, Y = 3, Content=80},
            } };
            pnlMap.KnownQuadrants = _ourTeam.KnownQuadrants;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Guid guid = AdminServiceClient();
            var gameGuidForm = new GameGuidForm(adminClient);
            if (gameGuidForm.ShowDialog() == DialogResult.OK)
            {
                ServiceClient  = new ServiceClient(_baseUri, gameGuidForm.ValidGameGuid);
                CurrentGame = ServiceClient.GetGameInfo();
                
                pnlMap.WidthInQuadrants = CurrentGame.GameAreaWidthInQuadrants;
                pnlMap.HeightInQuadrants = CurrentGame.GameAreaHeightInQuadrants;
            }
        }
    }
}
