
namespace MSSQL2019.Allocation.Dissector
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.日志跟踪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志跟踪ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allocationWindow1 = new InternalsViewer.UI.AllocationWindow();
            this.解码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日志跟踪ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 日志跟踪ToolStripMenuItem
            // 
            this.日志跟踪ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日志跟踪ToolStripMenuItem1,
            this.解码ToolStripMenuItem});
            this.日志跟踪ToolStripMenuItem.Name = "日志跟踪ToolStripMenuItem";
            this.日志跟踪ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.日志跟踪ToolStripMenuItem.Text = "工具";
            // 
            // 日志跟踪ToolStripMenuItem1
            // 
            this.日志跟踪ToolStripMenuItem1.Name = "日志跟踪ToolStripMenuItem1";
            this.日志跟踪ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.日志跟踪ToolStripMenuItem1.Text = "日志跟踪";
            this.日志跟踪ToolStripMenuItem1.Click += new System.EventHandler(this.OnLogMonitor);
            // 
            // allocationWindow1
            // 
            this.allocationWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allocationWindow1.Location = new System.Drawing.Point(0, 25);
            this.allocationWindow1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allocationWindow1.Name = "allocationWindow1";
            this.allocationWindow1.Size = new System.Drawing.Size(970, 655);
            this.allocationWindow1.TabIndex = 3;
            // 
            // 解码ToolStripMenuItem
            // 
            this.解码ToolStripMenuItem.Name = "解码ToolStripMenuItem";
            this.解码ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.解码ToolStripMenuItem.Text = "解码";
            this.解码ToolStripMenuItem.Click += new System.EventHandler(this.OnDecoode);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 680);
            this.Controls.Add(this.allocationWindow1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "MSSQL2019.Allocation.Dissector";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private InternalsViewer.UI.AllocationWindow allocationWindow1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 日志跟踪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志跟踪ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 解码ToolStripMenuItem;
    }
}

