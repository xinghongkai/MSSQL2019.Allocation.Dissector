using System;
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
			//Backup the database			
			VdiEngine BackupDevice = new VdiEngine();
			BackupDevice.CommandIssued += new EventHandler<CommandIssuedEventArgs>(BackupDevice_CommandIssued);
			BackupDevice.InfoMessageReceived += new EventHandler<InfoMessageEventArgs>(BackupDevice_InfoMessageReceived);

			using (FileStream BackupStream = new FileStream("C:\\Out.bak", FileMode.Create, FileAccess.Write, FileShare.None, BufferSize))
			{
				using (DeflateStream CompressedBackupStream = new DeflateStream(BackupStream, CompressionMode.Compress))
				{
					DateTime Start = DateTime.Now;
					BackupDevice.ExecuteCommand("BACKUP DATABASE AdventureWorks TO VIRTUAL_DEVICE='{0}' WITH STATS = 1", CompressedBackupStream);
					Console.WriteLine(DateTime.Now.Subtract(Start));
				}
			}

			using (FileStream RestoreStream = new FileStream("C:\\Out.bak", FileMode.Open, FileAccess.Read, FileShare.None, BufferSize))
			{
				using (DeflateStream CompressedRestoreStream = new DeflateStream(RestoreStream, CompressionMode.Decompress))
				{
					DateTime Start = DateTime.Now;
					BackupDevice.ExecuteCommand("RESTORE VERIFYONLY FROM VIRTUAL_DEVICE = '{0}' WITH STATS = 1", CompressedRestoreStream);
					Console.WriteLine(DateTime.Now.Subtract(Start));
				}
			}
			
			Console.WriteLine("Done");
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