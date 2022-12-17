using ServiceClientClassLibrary;
using ServiceClientClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace MiningClient;
public partial class MainForm : Form
{
    private static readonly Uri BASE_URI = new Uri("https://localhost:44351/api/");
    public MiningGameDto CurrentGame { get; set; }
    public Team _ourTeam { get; set; }
    public static ServiceClient ServiceClient { get; set; }
    public static AdminServiceClient AdminClient { get; set; }

    public MainForm()
    {
        InitializeComponent();
         AdminClient = new (BASE_URI);
        AdminClient.CreateGame("Our game", 32);
        _ourTeam = new Team() {Name = "Our team", KnownQuadrants = new List<MapSquareDto>() { new MapSquareDto() { X = 2, Y = 7, Value=10} ,
        new MapSquareDto() { X = 11, Y = 5, Value=50},
        new MapSquareDto() { X = 8, Y = 3, Value=80},
        } };
        pnlMap.KnownMapSquares = _ourTeam.KnownQuadrants;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        //Guid guid = AdminServiceClient();
        var gameGuidForm = new GameGuidForm(AdminClient);
        if (gameGuidForm.ShowDialog() == DialogResult.OK)
        {
            ServiceClient  = new ServiceClient(BASE_URI, gameGuidForm.ValidGameGuid);
            CurrentGame = ServiceClient.GetGameInfo();
            
            pnlMap.MapSideLength = CurrentGame.MapSideLength;
        }
    }
}
