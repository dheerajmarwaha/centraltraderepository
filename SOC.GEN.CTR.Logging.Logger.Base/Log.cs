using Serilog;
using SOC.GEN.CTR.Common;
using SOC.GEN.CTR.Logging.Logger.Contracts;
using System;
using System.IO;

namespace SOC.GEN.CTR.Logging.Logger.Base
{
    /// <summary>
    /// Base class for the logging providers and implements the <see cref="EC.VL.Logging.Logger.Contracts.IStructuredLog"/> interface
    /// </summary>
    public abstract class Log : IStructuredLog
    {
        /// <summary>
        /// Default output template for structured file logging. 
        /// </summary>
        protected const string DefaultOutputTemplate = "{Timestamp}[{Level}]{Message}{NewLine}{Exception}";
        ILogger _Logger;

        /// <summary>
        /// Initiates the serlog diagnostic log
        /// </summary>
        static Log()
        {
            try
            {
                var diagPath = string.IsNullOrEmpty(ConfigurationManager.Configuration["Serilog:Diagnostics:Path"]) ? "serilog.log" : ConfigurationManager.Configuration["Serilog:Diagnostics:Path"];
                Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(File.CreateText(diagPath)));
            }
            catch { }
        }

        /// <summary>
        /// Creates an instance of the logger
        /// </summary>
        public Log()
        {
            
        }

        /// <summary>
        /// Creates an instance with the passed logger instance
        /// </summary>
        /// <param name="logger"></param>
        public Log(ILogger logger)
        {
            try
            {
                _Logger = logger;
            }
            catch { }
        }

        /// <summary>
        /// Returns the logger instance
        /// </summary>
        public ILogger Logger
        {
            get { return _Logger; }
            protected set { try { _Logger = value; } catch { } }
        }

        /// <summary>
        /// Information level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Information(Exception exception, string message, params object[] propertyValues)
        {
            try { _Logger.Information(exception, message, propertyValues); } catch { }
        }

        /// <summary>
        /// Information level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Information(string message, params object[] propertyValues)
        {
            try { _Logger.Information(message, propertyValues); } catch { }
        }

        /// <summary>
        /// Error level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Error(string message, params object[] propertyValues)
        {
            try { _Logger.Error(message, propertyValues); } catch { }
        }

        /// <summary>
        /// Error level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Error(Exception exception, string message, params object[] propertyValues)
        {
            try { _Logger.Error(exception, message, propertyValues); } catch { }
        }

        /// <summary>
        /// Warning level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Warning(string message, params object[] propertyValues)
        {
            try { _Logger.Warning(message, propertyValues); } catch { }
        }

        /// <summary>
        /// Warning level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Warning(Exception exception, string message, params object[] propertyValues)
        {
            try { _Logger.Warning(exception, message, propertyValues); } catch { }
        }

        /// <summary>
        /// Fatal level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Fatal(string message, params object[] propertyValues)
        {
            try { _Logger.Fatal(message, propertyValues); } catch { }
        }

        /// <summary>
        /// Fatal level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Fatal(Exception exception, string message, params object[] propertyValues)
        {
            try { _Logger.Fatal(exception, message, propertyValues); } catch { }
        }

        /// <summary>
        /// Debug level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Debug(string message, params object[] propertyValues)
        {
            try { _Logger.Debug(message, propertyValues); } catch { }
        }

        /// <summary>
        /// Debug message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        public void Debug(Exception exception, string message, params object[] propertyValues)
        {
            try { _Logger.Debug(exception, message, propertyValues); } catch (Exception ex){ }
        }

        /// <summary>
        /// Returns Serilog LogLevel
        /// </summary>
        /// <param name="level">Level string</param>
        /// <returns>Serilog LogEventLevel</returns>
        protected Serilog.Events.LogEventLevel GetLevel(string level)
        {
            try
            {
                return
                    String.IsNullOrEmpty(level) ? Serilog.Events.LogEventLevel.Information :
                    level.Equals("Off", System.StringComparison.InvariantCultureIgnoreCase) ? ((Serilog.Events.LogEventLevel)1 + (int)Serilog.Events.LogEventLevel.Fatal) :
                    level.Equals("Verbose", System.StringComparison.InvariantCultureIgnoreCase) ? Serilog.Events.LogEventLevel.Verbose :
                    level.Equals("Debug", System.StringComparison.InvariantCultureIgnoreCase) ? Serilog.Events.LogEventLevel.Debug :
                    level.Equals("Information", System.StringComparison.InvariantCultureIgnoreCase) ? Serilog.Events.LogEventLevel.Information :
                    level.Equals("Warning", System.StringComparison.InvariantCultureIgnoreCase) ? Serilog.Events.LogEventLevel.Warning :
                    level.Equals("Error", System.StringComparison.InvariantCultureIgnoreCase) ? Serilog.Events.LogEventLevel.Error :
                    level.Equals("Fatal", System.StringComparison.InvariantCultureIgnoreCase) ? Serilog.Events.LogEventLevel.Fatal :
                    level.Equals("Information", System.StringComparison.InvariantCultureIgnoreCase) ? Serilog.Events.LogEventLevel.Information : Serilog.Events.LogEventLevel.Verbose;
            }
            catch
            {
                return Serilog.Events.LogEventLevel.Information;
            }
        }

    }
}
