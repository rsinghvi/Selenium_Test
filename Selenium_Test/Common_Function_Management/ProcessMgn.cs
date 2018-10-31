using SAFINCA.LogMgn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAFINCA.CommonFuncMgn
{
    /// <summary>
    /// Management of the process, such as the running application process. Killing the process that is not used anymore
    /// </summary>
    class ProcessMgn
    {

        /// <summary>
        /// Kill a pocess given the name of the process
        /// The process is killed if the pocess is longer than 3 seconds
        /// </summary>
        /// <param name="nameOfProcessToKill"></param>
        public static void killProcessByNames(string nameOfProcessToKill)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), nameOfProcessToKill);
            string[] nameOfProcessToKillList = nameOfProcessToKill.Split(',');
            foreach (string nameOfProcess in nameOfProcessToKillList)
            {
                try
                {
                    foreach (Process proc in Process.GetProcessesByName(nameOfProcess))
                    {
                        DateTime procStartTime = proc.StartTime;
                        DateTime dateNow = DateTime.Now;
                        long diff = (long)(dateNow - procStartTime).TotalMilliseconds;
                        //Kill the process if longer than 3 secunds
                        if (diff > 3000 && !(proc.ProcessName.ToLower().Contains("excel")))
                        {
                            proc.Refresh();
                            proc.Kill();
                        }
                        if (proc.ProcessName.ToLower().Contains("excel") && diff < 3000)
                        {
                            proc.Refresh();
                            proc.Kill();
                        }
                    }
                }
                catch (Exception e)
                {
                    SAFINCALog.Warning("The process, " + nameOfProcessToKill + " could not be killed. See Exception: \n" + e);
                }
                Thread.Sleep(1000);
            }

        }

        /// <summary>
        /// Clear the cache for Inernet Explorer
        /// </summary>
        public static void ClearIECache()
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName());
            // Clear the special cache folder
            ClearFolder(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)));
        }

        /// <summary>
        /// Deletes all the files within the specified folder
        /// </summary>
        /// <param name="folder">The folder from which we wish to delete all of the files</param>
        public static void ClearFolder(DirectoryInfo folder)
        {
            SAFINCALog.Debug(CommonUtilities.GetClassAndMethodName(), folder.FullName);
            // Iterate each file
            foreach (FileInfo file in folder.GetFiles())
            {
                try
                {
                    // Delete the file, ignoring any exceptions
                    file.Delete();
                }
                catch (Exception)
                {
                }
            }

            // For each folder in the specified folder
            foreach (DirectoryInfo subfolder in folder.GetDirectories())
            {
                // Clear all the files in the folder
                ClearFolder(subfolder);
            }
        }
    }
}
