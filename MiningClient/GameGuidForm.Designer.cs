
namespace MiningClient
{
    partial class GameGuidForm
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
            this.lblEnterGameIdPrompt = new System.Windows.Forms.Label();
            this.txtGameId = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnterGameIdPrompt
            // 
            this.lblEnterGameIdPrompt.AutoSize = true;
            this.lblEnterGameIdPrompt.Location = new System.Drawing.Point(14, 17);
            this.lblEnterGameIdPrompt.Name = "lblEnterGameIdPrompt";
            this.lblEnterGameIdPrompt.Size = new System.Drawing.Size(437, 38);
            this.lblEnterGameIdPrompt.TabIndex = 0;
            this.lblEnterGameIdPrompt.Text = "Enter Game ID to search for game";
            // 
            // txtGameId
            // 
            this.txtGameId.Location = new System.Drawing.Point(14, 68);
            this.txtGameId.Name = "txtGameId";
            this.txtGameId.Size = new System.Drawing.Size(618, 45);
            this.txtGameId.TabIndex = 1;
            this.txtGameId.TextChanged += new System.EventHandler(this.txtGameId_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(812, 68);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 45);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(14, 131);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 38);
            this.lblStatus.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(648, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 45);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // GameGuidForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(936, 178);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtGameId);
            this.Controls.Add(this.lblEnterGameIdPrompt);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GameGuidForm";
            this.Text = "Game ID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterGameIdPrompt;
        private System.Windows.Forms.TextBox txtGameId;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCancel;
    }
}