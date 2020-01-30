
using System;
using Serilog;
using Serilog.Exceptions;
using SOC.GEN.CTR.Common;
using SOC.GEN.CTR.Logging.Logger.Contracts;

namespace SOC.GEN.CTR.Logging.Logger.SqlServerLogger
{
    /// <summary>
    /// MSSqlServer logging provider using Serilog
    /// </summary>
    public class SqlServerLogger : Base.Log, IDatabaseLogger
    {
        volatile DatabaseLogOptions _Options;

        /// <summary>
        /// Provides an instance of the logger. 
        /// Uses the config settings in the ConnectionStrings and AppSettings for options <see cref="SOC.GEN.CTR.Logging.Logger.Contracts.DatabaseLogOptions"/>, and if not available uses default options of Serilog.
        /// AppSettings keys are as follows:
        /// SqlServerLog.Table    -- Table name to store the logs
        /// SqlServerLog.BatchSize -- Batch size
        /// SqlServerLog.Interval.Seconds -- Batch interval
        /// SqlServerLog.Level -- Accepted values are Verbose, Information, Debug, Warning, Error, Fatal, Off. the value "Off" will turn off the logger
        /// </summary>
        public SqlServerLogger()
        {
            try
            {
                int batchSize;
                int interval;
                if (!int.TryParse(ConfigurationManager.Configuration["SqlServerLog:BatchSize"], out batchSize)) batchSize = 1;
                if (!int.TryParse(ConfigurationManager.Configuration["SqlServerLog:Interval:Seconds"], out interval)) interval = 1;

                _Options = new DatabaseLogOptions
                {
                    ConnectionString = ConfigurationManager.Configuration["SqlServerLog:ConnectionString"],
                    Table = ConfigurationManager.Configuration["SqlServerLog:Table"],
                    BatchSize = batchSize,
                    Interval = new TimeSpan(0, 0, interval),
                    LogLevel = ConfigurationManager.Configuration["SqlServerLog:Level"]
                };

                Logger = CreateLogger();
                Current.Logger = this;
            }
            catch
            {
                throw;
                //ignore logging issues
            }
        }

        /// <summary>
        /// Options to be used by serilog for MsSqlServer database logging
        /// </summary>
        public DatabaseLogOptions LogOptions
        {
            get { return _Options; }
            set
            {
                try
                {
                    _Options = value;
                    Logger = CreateLogger();
                    Current.Logger = this;
                }
                catch
                {
                    //ignore log issues
                }
            }
        }

        /// <summary>
        /// Returns the current logger instance set for MsSqlServer database logging
        /// </summary>
        public static class Current
        {
            /// <summary>
            /// Current logger instance
            /// </summary>
            public static SqlServerLogger Logger
            {
                get;
                internal set;
            }
        }

        ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.MSSqlServer(
                     connectionString: _Options.ConnectionString,
                    tableName: string.IsNullOrEmpty(_Options.Table) ? "Log" : _Options.Table,
                    restrictedToMinimumLevel: GetLevel(_Options.LogLevel),
                    batchPostingLimit: _Options.BatchSize,
                    period: _Options.Interval
                  )
                .CreateLogger();
        }
    }
}
