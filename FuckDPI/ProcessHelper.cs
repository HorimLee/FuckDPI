﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ProcessHelper
{
    public static int ExecuteAndWait(string filename, string args, bool nowindow)
    {
        Process p = new Process();

        // Redirect the output stream of the child process.
        p.StartInfo.FileName = filename;
        p.StartInfo.Arguments = args;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = false;
        p.StartInfo.RedirectStandardOutput = false;
        p.StartInfo.CreateNoWindow = nowindow;
        p.Start();

        // Feed image buffer to the input stream of the child process.
        //p.StandardInput.Write(image_buffer, 0, image_buffer.Count())
        //p.StandardInput.BaseStream.Write(image_buffer, 0, image_buffer.Count());
        //p.StandardInput.Close();

        // Do not wait for the child process to exit before
        // reading to the end of its redirected stream.
        // p.WaitForExit();
        // Read the output stream first and then wait.
        //string result = p.StandardOutput.ReadToEnd();

        p.WaitForExit();

        return p.ExitCode;
    }
}
