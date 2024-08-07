using System;
using System.IO;

namespace Business.Helpers
{
    public class Logging
    {
        /// <summary>
        /// Logs the exception details to a log file.
        /// </summary>
        /// <param name="ex">The exception to be logged.</param>
        public static void LogException(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"Exception: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                writer.WriteLine($"Timestamp: {DateTime.Now}");
                writer.WriteLine("----------------------------------------");
            }
        }
    }
}
