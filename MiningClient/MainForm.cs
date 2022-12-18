using MiningApi.Authentication;
using ServiceClientClassLibrary;
using ServiceClientClassLibrary.Model;
using System;
using System.Linq;
using System.Windows.Forms;
namespace MiningClient;
public partial class MainForm : Form
{
    #region Properties
    private static readonly Uri BASE_URI = new Uri("https://localhost:44351/api/");
    public TeamDto _ourTeam { get; set; }
    public static ServiceClient ServiceClient { get; set; }
    public static AdminServiceClient AdminClient { get; set; }


    public MiningGameDto CurrentGame
    {
        get { return lstGames.SelectedItem as MiningGameDto; }
        set
        {
            lstGames.SelectedItem = value;
            SetAndShowCurrentGameOnMapPanel();
        }
    }
    #endregion

    public MainForm()
    {
        InitializeComponent();
        AdminClient = new(BASE_URI);
        lstGames.SelectedIndexChanged += (_, _) => CurrentGame = lstGames.SelectedItem as MiningGameDto;
        Load += (_, _) => LoadGamesFromServer();
        lstGames.DoubleClick += (_, _) => CopyAuthenticationTokenToClipboard();
    }

    private void CopyAuthenticationTokenToClipboard()
    {
        if (CurrentGame == null) { return; }
        var teams = AdminClient.GetTeamsFromGame(CurrentGame.Id).ToList();
        if (teams.Count() == 0) { return; }
        var token = TokenAuthenticationTool.GenerateToken(CurrentGame.Id, teams[0].Id);
        Clipboard.SetText(token);
    }

    private void SetAndShowCurrentGameOnMapPanel()
    {
        pnlMap.MapSideLength = CurrentGame?.MapSideLength ?? 0;
        pnlMap.KnownMapSquares = CurrentGame?.MapSquares;
        pnlMap.Refresh();
    }
    private void LoadGamesFromServer()
    {
        lstGames.Items.Clear();
        AdminClient.GetAll().ToList().ForEach(game => lstGames.Items.Add(game));
        if (lstGames.Items.Count > 0) { CurrentGame = lstGames.Items[0] as MiningGameDto; }
    }

    
}