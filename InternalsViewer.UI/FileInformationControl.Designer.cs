namespace InternalsViewer.UI
{
    partial class FileInformationControl
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.databaseFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.spaceUsedPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.allocationContainer1 = new InternalsViewer.UI.Allocations.AllocationContainer();
            this.allocationViewer1 = new InternalsViewer.UI.AllocationViewer();
            this.allocationWindow1 = new InternalsViewer.UI.AllocationWindow();
            ((System.ComponentModel.ISupportInitialize)(this.databaseFileBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(252, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "MB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(3, 51);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Used";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(169, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Extents";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "FileName", true));
            this.label18.Location = new System.Drawing.Point(79, 32);
            this.label18.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 15);
            this.label18.TabIndex = 16;
            this.label18.Text = "x";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Gray;
            this.label19.Location = new System.Drawing.Point(0, 52);
            this.label19.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 15);
            this.label19.TabIndex = 15;
            this.label19.Text = "Filegroup";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(86, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pages";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "Name", true));
            this.label17.Location = new System.Drawing.Point(168, 13);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 15);
            this.label17.TabIndex = 18;
            this.label17.Text = "x";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "FileGroup", true));
            this.label16.Location = new System.Drawing.Point(79, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 15);
            this.label16.TabIndex = 17;
            this.label16.Text = "x";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "FileId", true));
            this.label15.Location = new System.Drawing.Point(79, 13);
            this.label15.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "TotalPages", true));
            this.label9.Location = new System.Drawing.Point(88, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "12345678";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(116, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label13, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label14, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.spaceUsedPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(465, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 72);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "UsedPages", true));
            this.label10.Location = new System.Drawing.Point(88, 51);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "x";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "TotalExtents", true));
            this.label11.Location = new System.Drawing.Point(171, 29);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "x";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "UsedExtents", true));
            this.label12.Location = new System.Drawing.Point(171, 51);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "x";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "TotalMb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.label13.Location = new System.Drawing.Point(254, 29);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 15);
            this.label13.TabIndex = 13;
            this.label13.Text = "x";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.databaseFileBindingSource, "UsedMb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.label14.Location = new System.Drawing.Point(254, 51);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "x";
            // 
            // spaceUsedPanel
            // 
            this.spaceUsedPanel.BackColor = System.Drawing.Color.White;
            this.spaceUsedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spaceUsedPanel.Location = new System.Drawing.Point(5, 5);
            this.spaceUsedPanel.Margin = new System.Windows.Forms.Padding(5, 0, 13, 0);
            this.spaceUsedPanel.Name = "spaceUsedPanel";
            this.spaceUsedPanel.Padding = new System.Windows.Forms.Padding(1);
            this.spaceUsedPanel.Size = new System.Drawing.Size(65, 22);
            this.spaceUsedPanel.TabIndex = 8;
            this.spaceUsedPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceUsedPanel_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "File name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 72);
            this.panel1.TabIndex = 21;
            // 
            // allocationContainer1
            // 
            this.allocationContainer1.DrawBorder = true;
            this.allocationContainer1.ExtentSize = new System.Drawing.Size(64, 8);
            this.allocationContainer1.Holding = true;
            this.allocationContainer1.HoldingMessage = "";
            this.allocationContainer1.IncludeIam = false;
            this.allocationContainer1.LayoutStyle = InternalsViewer.UI.Allocations.LayoutStyle.Horizontal;
            this.allocationContainer1.Location = new System.Drawing.Point(0, 0);
            this.allocationContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.allocationContainer1.Mode = InternalsViewer.UI.Allocations.MapMode.Standard;
            this.allocationContainer1.Name = "allocationContainer1";
            this.allocationContainer1.ShowFileInformation = false;
            this.allocationContainer1.Size = new System.Drawing.Size(1067, 692);
            this.allocationContainer1.TabIndex = 22;
            // 
            // allocationViewer1
            // 
            this.allocationViewer1.Location = new System.Drawing.Point(0, 0);
            this.allocationViewer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.allocationViewer1.Name = "allocationViewer1";
            this.allocationViewer1.Size = new System.Drawing.Size(893, 478);
            this.allocationViewer1.TabIndex = 23;
            // 
            // allocationWindow1
            // 
            this.allocationWindow1.Location = new System.Drawing.Point(0, 0);
            this.allocationWindow1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.allocationWindow1.Name = "allocationWindow1";
            this.allocationWindow1.Size = new System.Drawing.Size(1260, 668);
            this.allocationWindow1.TabIndex = 24;
            // 
            // FileInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.allocationWindow1);
            this.Controls.Add(this.allocationViewer1);
            this.Controls.Add(this.allocationContainer1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FileInformationControl";
            this.Size = new System.Drawing.Size(800, 72);
            ((System.ComponentModel.ISupportInitialize)(this.databaseFileBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.BindingSource databaseFileBindingSource;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel spaceUsedPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private Allocations.AllocationContainer allocationContainer1;
        private AllocationViewer allocationViewer1;
        private AllocationWindow allocationWindow1;
    }
}
