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
            this.Checkbox_EnableTimerStart = new System.Windows.Forms.CheckBox();
            this.Checkbox_EnableFinalSplit = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.settingsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.ColumnCount = 1;
            this.settingsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.settingsPanel.Location = new System.Drawing.Point(3, 20);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.RowCount = 1;
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsPanel.Size = new System.Drawing.Size(470, 96);
            this.settingsPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.Checkbox_EnableLoadRemoval, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Checkbox_EnableTimerStart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Checkbox_EnableFinalSplit, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(451, 74);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Checkbox_EnableLoadRemoval
            // 
            this.Checkbox_EnableLoadRemoval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Checkbox_EnableLoadRemoval.AutoSize = true;
            this.Checkbox_EnableLoadRemoval.Location = new System.Drawing.Point(3, 3);
            this.Checkbox_EnableLoadRemoval.Name = "Checkbox_EnableLoadRemoval";
            this.Checkbox_EnableLoadRemoval.Size = new System.Drawing.Size(131, 17);
            this.Checkbox_EnableLoadRemoval.TabIndex = 1;
            this.Checkbox_EnableLoadRemoval.Text = "Enable Load Removal";
            this.Checkbox_EnableLoadRemoval.UseVisualStyleBackColor = true;
            // 
            // Checkbox_EnableTimerStart
            // 
            this.Checkbox_EnableTimerStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Checkbox_EnableTimerStart.AutoSize = true;
            this.Checkbox_EnableTimerStart.Location = new System.Drawing.Point(3, 27);
            this.Checkbox_EnableTimerStart.Name = "Checkbox_EnableTimerStart";
            this.Checkbox_EnableTimerStart.Size = new System.Drawing.Size(113, 17);
            this.Checkbox_EnableTimerStart.TabIndex = 2;
            this.Checkbox_EnableTimerStart.Text = "Enable Timer Start";
            this.Checkbox_EnableTimerStart.UseVisualStyleBackColor = true;
            // 
            // Checkbox_EnableFinalSplit
            // 
            this.Checkbox_EnableFinalSplit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Checkbox_EnableFinalSplit.AutoSize = true;
            this.Checkbox_EnableFinalSplit.Location = new System.Drawing.Point(3, 51);
            this.Checkbox_EnableFinalSplit.Name = "Checkbox_EnableFinalSplit";
            this.Checkbox_EnableFinalSplit.Size = new System.Drawing.Size(107, 17);
            this.Checkbox_EnableFinalSplit.TabIndex = 3;
            this.Checkbox_EnableFinalSplit.Text = "Enable Final Split";
            this.Checkbox_EnableFinalSplit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Removes loads on the game timer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Starts the timer automatically";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Splits on the ending cutscene";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.settingsPanel);
            this.Name = "UserSettings";
            this.Size = new System.Drawing.Size(476, 154);
            this.settingsPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel settingsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox Checkbox_EnableLoadRemoval;
    private System.Windows.Forms.CheckBox Checkbox_EnableTimerStart;
    private System.Windows.Forms.CheckBox Checkbox_EnableFinalSplit;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
  }
}
