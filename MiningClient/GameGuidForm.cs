using ServiceClientClassLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiningClient;

public partial class GameGuidForm : Form
{
    public string ValidGameGuid { get; set; }
    AdminServiceClient _adminClient;

    public GameGuidForm(AdminServiceClient adminServiceClient)
    {
        InitializeComponent();
        _adminClient = adminServiceClient;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        SaveAndClose();
    }

    private void SaveAndClose()
    {
        ValidGameGuid = txtGameId.Text;
        Close();
    }

    private bool CheckGameId(string gameId)
    {
        try
        {
            return _adminClient.DoesGameExist(gameId);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error retrieving game data: '{ex.Message}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private void txtGameId_TextChanged(object sender, EventArgs e)
    {
        if (CheckGameId(txtGameId.Text))
        {
            btnOk.Enabled = true;
            lblStatus.Text = "Game found!";
            lblStatus.ForeColor = Color.Green;
        }
        else
        {
            btnOk.Enabled = false;
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = "Game not found...";
        }
    }
}