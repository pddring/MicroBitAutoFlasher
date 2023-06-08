namespace MicroBitAutoFlasher
{
    partial class MBFlasher
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
            components = new System.ComponentModel.Container();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            timer = new System.Windows.Forms.Timer(components);
            lstLog = new ListBox();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(57, 17);
            statusLabel.Text = "Welcome";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 2000;
            timer.Tick += timer_Tick;
            // 
            // lstLog
            // 
            lstLog.Dock = DockStyle.Fill;
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(0, 0);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(800, 428);
            lstLog.TabIndex = 1;
            // 
            // MBFlasher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstLog);
            Controls.Add(statusStrip);
            Name = "MBFlasher";
            Text = "Micro:bit auto flasher tool";
            Load += MBFlasher_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer timer;
        private ListBox lstLog;
    }
}