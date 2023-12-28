using ControleDeDespesas.Enums;

namespace ControleDeDespesas.Utils
{
    public class Logger
    {
        /*
        public static bool CreateLog(string message, LogType logType, string logName)
        {
            try
            {
                string path = PathFinder.solutionDirectory().ToString() + @"\logs\";
                string filePath = Path.Combine(path, logName + ".txt");

                if (!File.Exists(filePath))
                {
                    FileStream file = File.Create(filePath);
                    file.Close();
                }

                using (StreamWriter writer = File.AppendText(filePath))
                {
                    AppendLog(message, logType, writer);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void AppendLog(string logMessage, LogType logType, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write($"[{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}]");
                txtWriter.Write("--------");
                txtWriter.WriteLine($"[{logType}]:{logMessage}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
    }

}
