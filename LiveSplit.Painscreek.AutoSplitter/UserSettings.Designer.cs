namespace LiveSplit.Painscreek.AutoSplitter
{
    partial class UserSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Checkbox_EnableLoadRemoval = new System.Windows.Forms.CheckBox();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.settingsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.ColumnCount = 1;
            this.settingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.settingsPanel.Controls.Add(this.lblDisclaimer, 0, 0);
            this.settingsPanel.Location = new System.Drawing.Point(3, 20);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.RowCount = 4;
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.settingsPanel.Size = new System.Drawing.Size(470, 398);
            this.settingsPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.Checkbox_EnableLoadRemoval, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(451, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Checkbox_EnableLoadRemoval
            // 
            this.Checkbox_EnableLoadRemoval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Checkbox_EnableLoadRemoval.AutoSize = true;
            this.Checkbox_EnableLoadRemoval.Location = new System.Drawing.Point(3, 5);
            this.Checkbox_EnableLoadRemoval.Name = "Checkbox_EnableLoadRemoval";
            this.Checkbox_EnableLoadRemoval.Size = new System.Drawing.Size(131, 17);
            this.Checkbox_EnableLoadRemoval.TabIndex = 1;
            this.Checkbox_EnableLoadRemoval.Text = "Enable Load Removal";
            this.Checkbox_EnableLoadRemoval.UseVisualStyleBackColor = true;
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisclaimer.AutoSize = true;
            this.lblDisclaimer.ForeColor = System.Drawing.Color.Red;
            this.lblDisclaimer.Location = new System.Drawing.Point(3, 0);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Size = new System.Drawing.Size(464, 100);
            this.lblDisclaimer.TabIndex = 1;
            this.lblDisclaimer.Text = "Attention: This component is still under development!";
            this.lblDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.settingsPanel);
            this.Name = "UserSettings";
            this.Size = new System.Drawing.Size(476, 438);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel settingsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox Checkbox_EnableLoadRemoval;
        private System.Windows.Forms.Label lblDisclaimer;
    }
}
