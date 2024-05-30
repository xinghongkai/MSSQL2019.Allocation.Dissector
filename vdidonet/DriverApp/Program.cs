using System;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using VdiDotNet;

namespace DriverApp
{
	class Program
	{
		public static int BufferSize = 1048576;
		static void Main(string[] args)
		{
			try
            {
				//Backup the database			
				VdiEngine BackupDevice = new VdiEngine();
				BackupDevice.CommandIssued += new EventHandler<CommandIssuedEventArgs>(BackupDevice_CommandIssued);
				BackupDevice.InfoMessageReceived += new EventHandler<InfoMessageEventArgs>(BackupDevice_InfoMessageReceived);

				using (FileStream BackupStream = new FileStream("C:\\Logs\\Out.bak", FileMode.Create|FileMode.Append, FileAccess.Write, FileShare.None, BufferSize))
				{
					using (DeflateStream CompressedBackupStream = new DeflateStream(BackupStream, CompressionMode.Compress))
					{
						DateTime Start = DateTime.Now;
						BackupDevice.ExecuteCommand(ConfigurationManager.ConnectionStrings["VdiConnection"].ConnectionString,ConfigurationManager.AppSettings["BackUpSql"], CompressedBackupStream);
						Console.WriteLine(DateTime.Now.Subtract(Start));

					}
				}
				//using (FileStream RestoreStream = new FileStream("C:\\Out.bak", FileMode.Open, FileAccess.Read, FileShare.None, BufferSize))
				//{
				//	using (DeflateStream CompressedRestoreStream = new DeflateStream(RestoreStream, CompressionMode.Decompress))
				//	{
				//		DateTime Start = DateTime.Now;
				//		BackupDevice.ExecuteCommand("RESTORE VERIFYONLY FROM VIRTUAL_DEVICE = '{0}' WITH STATS = 1", CompressedRestoreStream);
				//		Console.WriteLine(DateTime.Now.Subtract(Start));
				//	}
				//}
			}
			catch(Exception ex)
            {

            }

			
			Console.WriteLine("Backup Done");

			using (FileStream BackupStream = new FileStream("C:\\Logs\\Out.bak", FileMode.Open, FileAccess.Read, FileShare.None, BufferSize))
			{
				using (FileStream BackupunzipStream = new FileStream("C:\\Logs\\Out.unZip.bak", FileMode.Create, FileAccess.Write, FileShare.ReadWrite, BufferSize))
				{
					using (var deflateStream = new DeflateStream(BackupStream, CompressionMode.Decompress, true))
					{
						var buf = new byte[1024];
						int len;
						while ((len = deflateStream.Read(buf, 0, buf.Length)) > 0)
                        {
							BackupunzipStream.Write(buf, 0, len);
							BackupunzipStream.Flush();
                        }
					}
				}
			}
			Console.WriteLine("Unzip Done");

			Console.ReadLine();
		}

		static void BackupDevice_InfoMessageReceived(object sender, InfoMessageEventArgs e)
		{
			Console.WriteLine(e.Message);
		}

		static void BackupDevice_CommandIssued(object sender, CommandIssuedEventArgs e)
		{
			Console.WriteLine(e.Command);
		}

	}
}