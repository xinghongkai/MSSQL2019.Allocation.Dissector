
namespace MSSQL2019.Allocation.Dissector
{
    partial class PageViewerForm
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
            this.pageViewerWindow1 = new InternalsViewer.UI.PageViewerWindow();
            this.SuspendLayout();
            // 
            // pageViewerWindow1
            // 
            this.pageViewerWindow1.ConnectionString = null;
            this.pageViewerWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageViewerWindow1.Location = new System.Drawing.Point(0, 0);
            this.pageViewerWindow1.Name = "pageViewerWindow1";
            this.pageViewerWindow1.Page = null;
            this.pageViewerWindow1.Size = new System.Drawing.Size(896, 586);
            this.pageViewerWindow1.TabIndex = 0;
            // 
            // PageViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 586);
            this.Controls.Add(this.pageViewerWindow1);
            this.Name = "PageViewerForm";
            this.Text = "PageViewerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private InternalsViewer.UI.PageViewerWindow pageViewerWindow1;
    }
}