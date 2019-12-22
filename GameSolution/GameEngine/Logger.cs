using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameEngine
{

    public sealed class Logger
    {

        private static Logger availableInstance = null;

        private static readonly object lockHandler = new object();

        private static readonly string filePathBase = @"C:\logging\BeatMyBot\";
        
        private Logger() { }

        public void LogError (string errorFunction, string errorDetails)
        {

            var dateFileHandle = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            using (StreamWriter sw = File.AppendText($"{filePathBase}BMB_{dateFileHandle}.log"))
            {

                sw.WriteLine($"{DateTime.Now.ToLongDateString()} - {DateTime.Now.ToLongTimeString()}");
                sw.WriteLine($"  :{errorFunction} - {errorDetails}");
                sw.WriteLine("");

            }

        }

        public static Logger Instance
        {
            get
            {
                lock (lockHandler)
                {
                    if (availableInstance == null)
                    {
                        availableInstance = new Logger();
                    }

                    return availableInstance;
                }
            }
        }

    }

}
