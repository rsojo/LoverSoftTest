using System;
using System.IO;

namespace Business.Helpers
{
    public class Logging
    {
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
