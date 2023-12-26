
using InternalsViewer.UI;

namespace MSSQL2019.Allocation.Dissector
{
    partial class DecodeForm
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

        public DecodeWindow DecoderWindow
        {
            get { return decodeWindow1; }
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.decodeWindow1 = new InternalsViewer.UI.DecodeWindow();
            this.SuspendLayout();
            // 
            // decodeWindow1
            // 
            this.decodeWindow1.Location = new System.Drawing.Point(13, 13);
            this.decodeWindow1.MinimumSize = new System.Drawing.Size(376, 125);
            this.decodeWindow1.Name = "decodeWindow1";
            this.decodeWindow1.ParentWindow = null;
            this.decodeWindow1.Size = new System.Drawing.Size(376, 125);
            this.decodeWindow1.TabIndex = 0;
            // 
            // DecodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 143);
            this.Controls.Add(this.decodeWindow1);
            this.Name = "DecodeForm";
            this.Text = "DecodeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private InternalsViewer.UI.DecodeWindow decodeWindow1;
    }
}