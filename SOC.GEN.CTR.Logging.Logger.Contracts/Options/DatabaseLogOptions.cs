using System;
using System.Collections.Generic;
using System.Text;

namespace SOC.GEN.CTR.Logging.Logger.Contracts
{
    /// <summary>
    /// Options to configure the database logger. Loggers such as Serilog, require a specific table schema
    /// </summary>
    public class DatabaseLogOptions
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Database table name
        /// </summary>
        public string Table { get; set; }
        /// <summary>
        /// Number of log records to be committed to the database in a batch
        /// </summary>
        public int BatchSize { get; set; }
        /// <summary>
        /// Time interval between batch logging
        /// </summary>
        public TimeSpan Interval { get; set; }
        /// <summary>
        /// Log level - Off, Verbose, Information, Debug, Warning, Error, Fatal. Default is Information
        /// </summary>
        public string LogLevel { get; set; }
    }
}
