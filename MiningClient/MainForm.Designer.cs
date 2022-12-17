
using MiningClient.CustomControls;

namespace MiningClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblGamesTitle = new System.Windows.Forms.Label();
            this.lstGames = new System.Windows.Forms.ListBox();
            this.pnlMap = new MiningClient.CustomControls.ProspectingPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblGamesTitle);
            this.splitContainer1.Panel1.Controls.Add(this.lstGames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlMap);
            this.splitContainer1.Size = new System.Drawing.Size(1570, 1104);
            this.splitContainer1.SplitterDistance = 523;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblGamesTitle
            // 
            this.lblGamesTitle.AutoSize = true;
            this.lblGamesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGamesTitle.Location = new System.Drawing.Point(0, 0);
            this.lblGamesTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGamesTitle.Name = "lblGamesTitle";
            this.lblGamesTitle.Size = new System.Drawing.Size(101, 38);
            this.lblGamesTitle.TabIndex = 1;
            this.lblGamesTitle.Text = "Games";
            // 
            // lstGames
            // 
            this.lstGames.FormattingEnabled = true;
            this.lstGames.ItemHeight = 38;
            this.lstGames.Location = new System.Drawing.Point(-3, 43);
            this.lstGames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstGames.Name = "lstGames";
            this.lstGames.Size = new System.Drawing.Size(522, 1030);
            this.lstGames.TabIndex = 0;
            // 
            // pnlMap
            // 
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(0, 0);
            this.pnlMap.MapSideLength = 1;
            this.pnlMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(1041, 1104);
            this.pnlMap.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 1104);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Mining game administrator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ProspectingPanel pnlMap;
        private System.Windows.Forms.ListBox lstGames;
        private System.Windows.Forms.Label lblGamesTitle;
    }
}

