using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var result = ExecuteCommand("call \"C:/Program Files/git/bin/git.exe\" diff --name-only develop $(git merge-base master develop)>>Delta.diff");
			Application.Run(new Form1());
		}

		/// <summary>
		/// Execute command line command & return Status code
		/// </summary>
		/// <param name="command"></param>
		/// <returns>Status code</returns>
		static int ExecuteCommand(string command)
		{
			var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
			//processInfo.CreateNoWindow = true;
			//processInfo.UseShellExecute = false;
			processInfo.RedirectStandardError = true;
			processInfo.RedirectStandardOutput = true;

			var process = Process.Start(processInfo);

			process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
				Console.WriteLine("output>>" + e.Data);
			process.BeginOutputReadLine();

			process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
				Console.WriteLine("error>>" + e.Data);
			process.BeginErrorReadLine();

			process.WaitForExit();

			Console.WriteLine("ExitCode: {0}", process.ExitCode);
			int status = process.ExitCode;
			process.Close();
			return status;
		}
	}
}
