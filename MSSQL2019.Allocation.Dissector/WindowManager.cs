using System;
using System.Data;
using System.Reflection;
using InternalsViewer.Internals;
using InternalsViewer.Internals.Pages;
using InternalsViewer.Internals.TransactionLog;
using InternalsViewer.UI;

namespace MSSQL2019.Allocation.Dissector
{
    /// <summary>
    /// Manages SSMS ToolWindow/Document integration
    /// </summary>
    class WindowManager
    {
        LogSequenceNumber startLsn;
        /// <summary>
        /// Creates a page viewer window with the application level connection string
        /// </summary>
        /// <param name="pageAddress">The page address.</param>
        /// <returns></returns>
        public PageViewerForm CreatePageViewerWindow(RowIdentifier rowIdentifier)
        {

            return CreatePageViewerWindow(InternalsViewerConnection.CurrentConnection().ConnectionString, rowIdentifier);
        }

        /// <summary>
        /// Creates a page viewer window with a given connection string and page address
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="pageAddress">The page address.</param>
        /// <returns></returns>
        public PageViewerForm CreatePageViewerWindow(string connectionString, RowIdentifier rowIdentifier)
        {
            PageViewerForm form = new PageViewerForm();
            form.connectionString = connectionString;
            form.rowIdentifier = rowIdentifier;

            return form;
        }

        public DecodeForm CreateDecodeWindow()
        {
            DecodeForm df = new DecodeForm();
            return df;
        }
    }
}
