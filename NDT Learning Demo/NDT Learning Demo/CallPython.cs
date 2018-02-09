using System;
using System.Diagnostics;

namespace NDT_Learning_Demo
{
    public static class CallPython
    {
        public static void RunPythonScript(string path, string args = "")
        {
            path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + path;
            Process p = new Process();
            p.StartInfo.FileName = "python35.exe";
            string sArguments = "\"" + path + "\"";
            if (args.Length > 0)
            {
                sArguments += " " + args;
            }
            // MessageBox.Show(sArguments);
            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = true;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.RedirectStandardInput = true;
            //p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.CloseMainWindow();
            p.WaitForExit();
            p.Close();
            p.Dispose();
        }
    }
}