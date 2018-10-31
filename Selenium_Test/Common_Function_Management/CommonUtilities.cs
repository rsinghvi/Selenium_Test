using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAFINCA.LogMgn;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace SAFINCA.CommonFuncMgn
{
    /// <summary>
    /// Include several utilities such as getCurrentTime
    /// </summary>
    public class CommonUtilities : SAFINCALog
    {

        public static long GetCurrentTimeMillis()
        {
            SAFINCALog.Debug(GetClassAndMethodName());
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)((DateTime.UtcNow - Jan1st1970).TotalMilliseconds);
        }

        public static string GetCurrentDate()
        {
            SAFINCALog.Debug(GetClassAndMethodName());
            DateTime dt = DateTime.Now;
            string date = dt.ToString("dd_MM_yyyy_HH_mm_ss");
            return date;
        }

        public static String GetClassAndMethodName()
        {
            StackTrace stackTraceElements = new StackTrace(true);
            String className = stackTraceElements.GetFrame(1).GetMethod().DeclaringType.Name;
            String methodName = stackTraceElements.GetFrame(1).GetMethod().Name;
            if (methodName.Contains("."))
            {
                methodName = stackTraceElements.GetFrame(2).GetMethod().DeclaringType.Name;
            }
            return className.PadRight(40) + methodName;
        }

        public static String GetMethodName()
        {
            StackTrace stackTraceElements = new StackTrace(true);
            String methodName = stackTraceElements.GetFrame(1).GetMethod().Name;
            if (methodName.Contains("."))
            {
                methodName = stackTraceElements.GetFrame(2).GetMethod().DeclaringType.Name;
            }
            return methodName;
        }

        public static String GetClassAndCallingMethodName()
        {
            StackTrace stackTraceElements = new StackTrace(true);
            String className = stackTraceElements.GetFrame(2).GetMethod().DeclaringType.Name;
            String methodName = stackTraceElements.GetFrame(2).GetMethod().Name;
            if (methodName.Contains("."))
            {
                methodName = stackTraceElements.GetFrame(3).GetMethod().DeclaringType.Name;
            }
            return className.PadRight(40) + methodName;
        }

        public static string GetClassName()
        {
            StackTrace stackTraceElements = new StackTrace(true);
            String className = stackTraceElements.GetFrame(1).GetMethod().DeclaringType.Name;
            return className;
        }

        public static string CreateFolder(string folderPath)
        {
            SAFINCALog.Debug(GetClassAndMethodName());
            string fullDirectoryPath = GetProjectDirectory() + folderPath;
            if (!Directory.Exists(fullDirectoryPath))
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }
            return fullDirectoryPath;
        }

        public static string GetOutPutDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        }

        public static string GetProjectDirectory()
        {
            SAFINCALog.Debug(GetClassAndMethodName());
            var outPutDirectory = GetOutPutDirectory();
            int startIndex = outPutDirectory.IndexOf("\\") + 1;
            int binIndex = outPutDirectory.IndexOf("bin");
            int length = binIndex - startIndex;
            string projectDir = outPutDirectory.Substring(startIndex, length);
            return projectDir;
        }

        /// <summary>
        /// Take a print screen and save the image as .png file.
        /// </summary>
        /// <param name="imageFullPathAndName"></param>
        public static void CreateAndSaveScreenShot(string imageFullPathAndName)
        {
            SAFINCALog.Debug(GetClassAndMethodName());
            Screen screen = Screen.PrimaryScreen;
            Bitmap bmp = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(0, 0, 0, 0, new Size(screen.Bounds.Width, screen.Bounds.Height));
            bmp.Save(imageFullPathAndName, ImageFormat.Png);
            string imageFullPathAndNameWithoutC = imageFullPathAndName.Replace("C:", "").Replace("C:", "");
            string imageFullPathAndNameIncludeFile = "file://///" + System.Environment.MachineName + imageFullPathAndNameWithoutC;
            SAFINCALog.Info("The screenshot is saved: " + imageFullPathAndNameIncludeFile);
        }

        /// <summary>
        /// Compare 2 XML files, line by line, 
        /// Throw an error if and char mismatch in a line
        /// Break lines are introduced into the before the comparison
        /// Example of use: CommonUtilities.CompareTwoXMLFiles(@"C:\TEMP\JWIKSQ_07TC002_20140812_130943BEP.xml.xml", @"C:\TEMP\JWIKSQ_07TC002_20140813_104157BEP.xml.xml", "ExecuteDate", "</value>");
        /// </summary>
        /// <param name="pathToOriginalFile"></param>
        /// <param name="pathToFileToCompare"></param>
        /// <param name="stringsToIgnoreCommaSeperated"></param>
        public static void CompareTwoXMLFiles(string pathToOriginalFile, string pathToFileToCompare, params string[] stringsToIgnoreCommaSeperated)
        {
            string pathToOriginalFileTemp=FormatXMLInsertBreakLine(pathToOriginalFile);
            string pathToFileToCompareTemp=FormatXMLInsertBreakLine(pathToFileToCompare);
            CompareTwoFiles(pathToOriginalFileTemp, pathToFileToCompareTemp, stringsToIgnoreCommaSeperated);           
        }


        /// <summary>
        /// Compare 2 files, line by line, 
        /// Throw an error if and char mismatch in a line
        /// </summary>
        /// <param name="pathToOriginalFile"></param>
        /// <param name="pathToFileToCompare"></param>
        /// <param name="stringsToIgnoreCommaSeperated"></param>
        public static void CompareTwoFiles(string pathToOriginalFile, string pathToFileToCompare, params string[] stringsToIgnoreCommaSeperated)
        {
            string errorMessage = "The following line did not match: \n ";
            bool isDiffBetweenFile = false;
            String[] linesOriginalFile = File.ReadAllLines(pathToOriginalFile);
            String[] linesCompareFile = File.ReadAllLines(pathToFileToCompare);

            int numberOfLines = linesOriginalFile.Length;
            int numberOfLineDiff = linesOriginalFile.Length - linesCompareFile.Length;
            if (linesOriginalFile.Length > linesCompareFile.Length)
            {
                numberOfLines = linesCompareFile.Length;
            }
            //loop through the lines
            for (int l = 0; l < numberOfLines; l++)
            {
                bool ignore = false;
                //Check if there is any ignore condition
                if (stringsToIgnoreCommaSeperated != null && stringsToIgnoreCommaSeperated.Length>0)
                {
                    foreach (string stringToIgnore in stringsToIgnoreCommaSeperated)
                    {
                        if (linesOriginalFile[l].Contains(stringToIgnore) && linesCompareFile[l].Contains(stringToIgnore))
                        {
                            ignore = true;
                            break;
                        }
                    }
                }
                //Check if the line in the original file match the line in the file to compare to 
                if (!ignore && !linesOriginalFile[l].Equals(linesCompareFile[l]))
                {

                    errorMessage = errorMessage + " Line: " + l + " Original line: " + linesOriginalFile[l] + " compare line: " + linesCompareFile[l] + "\n";
                    isDiffBetweenFile = true;
                }
            }
            //Throw an error if the ORIGINAL file has LESS lines than the file to compare with
            if (numberOfLineDiff < 0)
            {
                for (int restL = numberOfLines; restL < linesCompareFile.Length; restL++)
                {
                    errorMessage = errorMessage + restL + " compare line: " + linesCompareFile[restL];
                    isDiffBetweenFile = true;
                }
            }
            //Throw an error if the ORIGINAL file has MORE lines than the file to compare with
            else if (numberOfLineDiff > 0)
            {
                for (int restL = numberOfLines; restL < linesOriginalFile.Length; restL++)
                {
                    errorMessage = errorMessage + restL + "  Original line: " + linesOriginalFile[restL];
                    isDiffBetweenFile = true;
                }
            }

            if (isDiffBetweenFile)
            {
                throw new Exception(errorMessage);
            }
        }


        /// <summary>
        /// Return a path to a new file with break lines. 
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        static string FormatXMLInsertBreakLine(string pathToFile)
        {
            string pathToFileTemp = pathToFile + "temp";
            String[] linesOriginalFile = File.ReadAllLines(pathToFile);
            FileStream fileStream = new FileStream(pathToFileTemp, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            try
            {
                var stringBuilder = new StringBuilder();
                XElement element;
                foreach (var readLine in linesOriginalFile)
                {
                    int countOpeningTag = readLine.Length - readLine.Replace("<", "").Length;
                    int countClosingTag = readLine.Length - readLine.Replace(">", "").Length;
                    if (countOpeningTag > 1 & countClosingTag > 1)
                    {
                        element = XElement.Parse(readLine.ToString());
                        var settings = new XmlWriterSettings();
                        settings.OmitXmlDeclaration = true;
                        settings.Indent = true;
                        settings.NewLineOnAttributes = true;
                        using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
                        {
                            element.Save(xmlWriter);
                        }
                    }
                    else
                    {
                        stringBuilder.Append(readLine + "\n");
                        string s = stringBuilder.ToString();
                    }
                }
                streamWriter.Write(stringBuilder.ToString());
                streamWriter.Close();
            }
            catch
            {
                streamWriter.Close();
            }
            return pathToFileTemp;
        }

    }
}
