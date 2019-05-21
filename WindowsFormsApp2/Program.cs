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
			var result = ExecuteCommand(Application.StartupPath+"\\diff.bat", "develop", @"D:\Study\.Net Core\CoreWebAppDocker\");
			Application.Run(new Form1());
		}

		/// <summary>
		/// Execute command line command & return Status code
		/// </summary>
		/// <param name="command">Batch File</param>
		/// <param name="branchName">Branch Name</param>
		/// <returns>Status Code : 0 is success, all other code are errors</returns>
		public static int ExecuteCommand(string command, string branchName, string gitRepoPath)
		{
			int exitCode;
			ProcessStartInfo ProcessInfo;
			Process process;

			ProcessInfo = new ProcessStartInfo(command, branchName);//Application.StartupPath + "\\txtmanipulator\\txtmanipulator.bat", command);
			ProcessInfo.CreateNoWindow = true;
			ProcessInfo.UseShellExecute = false;
			//ProcessInfo.WorkingDirectory = Application.StartupPath + "\\txtmanipulator";
			// *** Redirect the output ***
			ProcessInfo.RedirectStandardError = true;
			ProcessInfo.RedirectStandardOutput = true;

			process = Process.Start(ProcessInfo);
			process.WaitForExit();

			// *** Read the streams ***
			string output = process.StandardOutput.ReadToEnd();
			string error = process.StandardError.ReadToEnd();

			exitCode = process.ExitCode;

			//MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
			//MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
			//MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
			process.Close();
			return exitCode;
		}
	}
}
