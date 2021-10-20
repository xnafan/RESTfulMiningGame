using ServiceClientClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiningClient
{
    public partial class GameGuidForm : Form
    {
        public Guid ValidGameGuid { get; set; }
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
            ValidGameGuid = new Guid(txtGameId.Text);
            Close();
        }

        private bool CheckGuid()
        {
            try
            {
                Guid gameGuid = new Guid(txtGameId.Text);
                return _adminClient.IsGameRunning(gameGuid);
            }
            catch (FormatException fex)
            {
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving game data: '{ex.Message}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtGameId_TextChanged(object sender, EventArgs e)
        {
            if (CheckGuid())
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
}