using System;
using System.Collections.Generic;
using System.Text;

namespace SOC.GEN.CTR.Logging.Logger.Contracts
{
    /// <summary>
    /// Options to configure the text file logger.
    /// </summary>
    public class FileLogOptions
    {
        /// <summary>
        /// Full path file name of the text file log
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Limit for the text log size in bytes
        /// </summary>
        public long? FileSizeLimitBytes { get; set; }
        /// <summary>
        /// Log level - Off, Verbose, Information, Debug, Warning, Error, Fatal. Default is Information
        /// </summary>
        public string LogLevel { get; set; }
        /// <summary>
        /// Default template to be applied on the log entries. The template text depends on the actual log provider. For example {Timestamp}[{Level}]{Message}{Newline}{Exception} as default template
        /// </summary>
        public string OutputTemplate { get; set; }

    }
}
