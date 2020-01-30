using Serilog;
using Serilog.Exceptions;
using SOC.GEN.CTR.Common;
using SOC.GEN.CTR.Logging.Logger.Contracts;
using System;

namespace SOC.GEN.CTR.Logging.Logger.FlatFileLogger
{
    /// <summary>
    /// Text file logging provider using Serilog
    /// </summary>
    public class FlatFileLogger : Base.Log, IFlatFileLogger
    {

        volatile FileLogOptions _Options;

        /// <summary>
        /// Provides an instance of the logger. 
        /// Uses the config settings in the AppSettings for options <see cref="EC.VL.Logging.Logger.Contracts.FileLogOptions"/>, and if not available uses default options of Serilog.
        /// AppSettings keys are as follows:
        /// TextFileLog.Path    E.g. <add key="TextFileLog.Path" value="c:\_logs\textfilelog.txt"/>. Default path is @".\Log.txt" and may need write permissions in webapp scenarios
        /// TextFileLog.FileSizeLimitBytes E.g.<add key="TextFileLog.FileSizeLimitBytes" value="2147483648"/> sets file size limit to 2GB
        /// TextFileLog.Level -- Accepted values are Verbose, Information, Debug, Warning, Error, Fatal, Off. the value "Off" will turn off the logger
        /// </summary>
        public FlatFileLogger()
        {
                try
                {
                    long logFileSizeLimit;
                    if (!long.TryParse(ConfigurationManager.Configuration["TextFileLog:FileSizeLimitBytes"], out logFileSizeLimit)) logFileSizeLimit = 1073741824;

                    _Options = new FileLogOptions
                    {
                        Path = String.IsNullOrEmpty(ConfigurationManager.Configuration["TextFileLog:Path"]) ? @".\Log.txt" : ConfigurationManager.Configuration["TextFileLog:Path"],
                        FileSizeLimitBytes = logFileSizeLimit,
                        LogLevel = ConfigurationManager.Configuration["TextFileLog:Level"],
                        OutputTemplate = string.IsNullOrEmpty(ConfigurationManager.Configuration["TextFileLog:OutputTemplate"]) ? DefaultOutputTemplate : ConfigurationManager.Configuration["TextFileLog:OutputTemplate"]
                    };

                    Logger = CreateLogger();

                    Current.Logger = this;
                }
                catch (Exception ex)
                {
                    //Ignore logging issues for smooth transition
                    //Extend it to write to another reliable sink - windows event or appinsight
                }
        }

        ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.RollingFile
                (
                    pathFormat: _Options.Path,
                    restrictedToMinimumLevel: GetLevel(_Options.LogLevel),
                    outputTemplate: _Options.OutputTemplate,
                    fileSizeLimitBytes: _Options.FileSizeLimitBytes
                )
                .CreateLogger();
        }

        /// <summary>
        /// Options to be used by serilog for text file logging
        /// </summary>
        public FileLogOptions LogOptions
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
                    //Ignore logging issues for smooth transition
                }
            }
        }

        /// <summary>
        /// Returns the current logger instance set for text file logging
        /// </summary>
        public static class Current
        {
            /// <summary>
            /// Current logger instance
            /// </summary>
            public static FlatFileLogger Logger
            {
                get;
                internal set;
            }
        }

    }
}
