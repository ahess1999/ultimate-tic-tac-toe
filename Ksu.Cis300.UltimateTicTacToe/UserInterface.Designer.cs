namespace Ksu.Cis300.UltimateTicTacToe
{
    partial class UserInterface
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
            this.uxBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.uxStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxBoard
            // 
            this.uxBoard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxBoard.Location = new System.Drawing.Point(12, 12);
            this.uxBoard.Name = "uxBoard";
            this.uxBoard.Size = new System.Drawing.Size(388, 338);
            this.uxBoard.TabIndex = 0;
            // 
            // uxStatus
            // 
            this.uxStatus.Location = new System.Drawing.Point(13, 357);
            this.uxStatus.Name = "uxStatus";
            this.uxStatus.ReadOnly = true;
            this.uxStatus.Size = new System.Drawing.Size(387, 20);
            this.uxStatus.TabIndex = 1;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 394);
            this.Controls.Add(this.uxStatus);
            this.Controls.Add(this.uxBoard);
            this.Name = "UserInterface";
            this.Text = "Ultimate Tic Tac Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uxBoard;
        private System.Windows.Forms.TextBox uxStatus;
    }
}

