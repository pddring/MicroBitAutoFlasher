using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace MicroBitAutoFlasher
{
    public class RobustCopy
    {
        /// <summary>
        /// Copy a file robustly (using Window's robocopy) which supports resuming if something goes wrong
        /// </summary>
        /// <param name="sourcePath">Location of source file (with trailing backslash)</param>
        /// <param name="filename">Name of file (no path - just filename)</param>
        /// <param name="destinationPath">Location to copy file to (with trailing backslash)</param>
        /// <param name="OnOutput">Optional callback handler to receive progress updates</param>
        /// <returns>Status code (int): 0 means successful copy</returns>
        public static int CopyFile(string sourcePath, string filename, string destinationPath, Func<string, int> OnOutput = null)
        {
            Process robocopy = new Process();
            robocopy.StartInfo.WorkingDirectory = sourcePath;
            robocopy.StartInfo.FileName = "robocopy";
            robocopy.StartInfo.ArgumentList.Add("/z");
            robocopy.StartInfo.ArgumentList.Add("/R:3");
            robocopy.StartInfo.ArgumentList.Add("/W:5");
            robocopy.StartInfo.ArgumentList.Add(".");
            robocopy.StartInfo.ArgumentList.Add(destinationPath);
            robocopy.StartInfo.ArgumentList.Add(filename);
            robocopy.StartInfo.UseShellExecute = false;
            robocopy.StartInfo.RedirectStandardOutput = true;
            robocopy.StartInfo.CreateNoWindow = true;

            robocopy.Start();
            // listen for any output
            if (OnOutput != null) {
                robocopy.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    OnOutput(e.Data);
                };
            }
            robocopy.BeginOutputReadLine();
            
            robocopy.WaitForExit();
            return robocopy.ExitCode;
        }

    }
}
