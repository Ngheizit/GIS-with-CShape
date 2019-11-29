using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace TianDiTuAPI
{
    class PyUtils
    {
        public static void RunPy(string filename, string args = "", params string[] teps)
        {
            string sArguments = filename;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }
            sArguments += " " + args;

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "python.exe",
                Arguments = sArguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            Process p = new Process()
            {
                StartInfo = startInfo
            };
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
        }
    }
}
