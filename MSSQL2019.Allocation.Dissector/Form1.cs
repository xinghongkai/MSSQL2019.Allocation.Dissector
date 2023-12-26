using InternalsViewer.Internals;
using InternalsViewer.Internals.Pages;
using InternalsViewer.Internals.TransactionLog;
using InternalsViewer.UI;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo.RegSvrEnum;
using Microsoft.SqlServer.Management.UI.ConnectionDlg;
using Microsoft.SqlServer.Management.UI.VSIntegration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSQL2019.Allocation.Dissector
{
    public partial class Form1 : Form
    {
        private WindowManager windowManager = new WindowManager();

        public static  LogSequenceNumber startLsn ;
        public Form1()
        {
            InitializeComponent();
            allocationWindow1.Connect += AllocationWindow1_Connect;
            this.allocationWindow1.ViewPage += new EventHandler<PageEventArgs>(AllocationWindowControl_ViewPage);
            this.allocationWindow1.DataBaseSelected += AllocationWindow1_DataBaseSelected;
        }

        private void AllocationWindow1_DataBaseSelected(object sender, DataBaseEventArgs e)
        {
            Form1.startLsn = LogMonitor.StartMonitoring(e.CurDatabase.ConnectionString, e.CurDatabase.Name);
        }

        void AllocationWindowControl_ViewPage(object sender, PageEventArgs e)
        {
            PageViewerForm form = windowManager.CreatePageViewerWindow(new RowIdentifier(e.Address, 0));
            form.Show();
            form.LoadPage();
        }



        private void AllocationWindow1_Connect(object sender, EventArgs e)
        {
            using (var dialog = new ShellConnectionDialog())
            {
                IServerType serverType = new SqlServerType();

                dialog.AddServer(serverType);

                var connectionInfo = new UIConnectionInfo();

                var hwnd = Process.GetCurrentProcess().MainWindowHandle;

                var win32Window = new NativeWindow();

                win32Window.AssignHandle(hwnd);

                if (dialog.ShowDialogCollectValues(win32Window, ref connectionInfo) == DialogResult.OK)
                {
                    this.Text = CreateSqlConnectionInfo(connectionInfo).ConnectionString;

                    ConnectInternalsViewer(connectionInfo);
                    this.allocationWindow1.RefreshDatabases();
                }
            }
        }

        internal void ConnectInternalsViewer(UIConnectionInfo connectionInfo)
        {
            ConnectInternalsViewer(CreateSqlConnectionInfo(connectionInfo));
        }

        /// <summary>
        /// Connects the internals viewer singleton
        /// </summary>
        /// <param name="connection">The connection.</param>
        internal static void ConnectInternalsViewer(SqlConnectionInfo connection)
        {
            InternalsViewerConnection.CurrentConnection().SetCurrentServer(connection.ServerName,
                                                                     connection.UseIntegratedSecurity,
                                                                     connection.UserName,
                                                                     connection.Password);
        }
        public  SqlConnectionInfo CreateSqlConnectionInfo(UIConnectionInfo connectionInfo)
        {
            var sqlConnInfo = new SqlConnectionInfo();

            sqlConnInfo.ServerName = connectionInfo.ServerName;
            sqlConnInfo.UserName = connectionInfo.UserName;

            if (string.IsNullOrEmpty(connectionInfo.Password))
            {
                sqlConnInfo.UseIntegratedSecurity = true;
            }
            else
            {
                sqlConnInfo.Password = connectionInfo.Password;
            }

            return sqlConnInfo;
        }
        private void PageViewerWindow_PageChanged(object sender, InternalsViewer.Internals.Pages.PageEventArgs e)
        {
            this.Text = "Page Viewer " + e.Address.ToString();
        }

        private void PageViewerWindow_OpenDecodeWindow(object sender, EventArgs e)
        {
        }

        private void PageViewerWindow_Load(object sender, EventArgs e)
        {
        }

        private void OnLogMonitor(object sender, EventArgs e)
        {
            TransactionLogViewerForm form = new TransactionLogViewerForm();
            form.Show();
        }

        private void OnDecoode(object sender, EventArgs e)
        {
            DecodeForm df = new DecodeForm();
            df.Show();
        }
    }
}
