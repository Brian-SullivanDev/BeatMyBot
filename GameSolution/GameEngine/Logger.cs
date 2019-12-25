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
        private static readonly object writingLock = new object();

        private static readonly string filePathBase = @"C:\logging\BeatMyBot\";
                
        private Logger()
        {

            /*

            var dateFileHandle = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            string fullFilePath = $"{filePathBase}BMB_{dateFileHandle}.log";

            if (!File.Exists(fullFilePath))
            {

                File.Create(fullFilePath);

            }

            */

        }

        /// <summary>
        /// create an error log entry according to the function and details provided
        /// </summary>
        /// <param name="errorFunction">unique pointer to the source of the error for locating the source of the log call</param>
        /// <param name="errorDetails">details of the specific error thrown to provide details as to what went wrong</param>
        public void LogError (string errorFunction, string errorDetails)
        {

            try
            {

                string logText = ""
                    + $"{DateTime.Now.ToLongDateString()} - {DateTime.Now.ToLongTimeString()}" + Environment.NewLine
                    + $"  :{errorFunction} - {errorDetails}" + Environment.NewLine
                    + Environment.NewLine;

                Console.Write(logText);

            }
            catch (Exception)
            {
                
            }

        }

        /// <summary>
        /// Get the single instance of the Logger (singleton)
        /// </summary>
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
