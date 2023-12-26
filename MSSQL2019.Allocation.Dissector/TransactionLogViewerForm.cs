using InternalsViewer.Internals;
using InternalsViewer.Internals.Pages;
using InternalsViewer.Internals.TransactionLog;
using InternalsViewer.UI;
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
    public partial class TransactionLogViewerForm : Form
    {
        WindowManager windowManager = new WindowManager();
        public string database = string.Empty;
        public string connectionString = string.Empty;
        public TransactionLogViewerForm()
        {
            InitializeComponent();

            database = InternalsViewerConnection.CurrentConnection().CurrentDatabase.Name;
            connectionString = InternalsViewerConnection.CurrentConnection().ConnectionString;

            TransactionLogTabPage transactionLogTabPage = new TransactionLogTabPage();
            Text = $"{database}-{Form1.startLsn}";

            transactionLogTabPage.SetTransactionLogData(LogMonitor.StopMonitoring(database, Form1.startLsn, connectionString));
            this.tabControl1.TabPages.Add(transactionLogTabPage);

            transactionLogTabPage.PageClicked += delegate (object sender, PageEventArgs args)
            {
                PageViewerForm form = this.windowManager.CreatePageViewerWindow(connectionString, args.RowId);
                form.LoadPage();
                form.SetLogData(transactionLogTabPage.LogContents);
                form.Show();
            };
        }
    }
}
