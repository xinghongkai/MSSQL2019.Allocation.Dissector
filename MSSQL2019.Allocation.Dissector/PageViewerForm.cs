using InternalsViewer.Internals.Pages;
using InternalsViewer.Internals.TransactionLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSQL2019.Allocation.Dissector
{
    public partial class PageViewerForm : Form
    {
        public string connectionString;
        public RowIdentifier rowIdentifier;
        WindowManager wm = new WindowManager();
        public PageViewerForm()
        {
            InitializeComponent();
            pageViewerWindow1.OpenDecodeWindow += PageViewerWindow1_OpenDecodeWindow;
            pageViewerWindow1.PageChanged += PageViewerWindow1_PageChanged;
        }

        private void PageViewerWindow1_PageChanged(object sender, PageEventArgs e)
        {
        }

        private void PageViewerWindow1_OpenDecodeWindow(object sender, EventArgs e)
        {
            DecodeForm df = wm.CreateDecodeWindow();
            df.DecoderWindow.ParentWindow = this.pageViewerWindow1;
            df.Show();
        }

        public void LoadPage()
        {
            pageViewerWindow1.LoadPage(connectionString, rowIdentifier);
            pageViewerWindow1.SetSlot(rowIdentifier.SlotId);
        }
        public void SetLogData(Dictionary<string, LogData> logData)
        {
            pageViewerWindow1.SetLogData(logData);
        }
    }
}
