using System;
using System.Collections.Generic;
using System.Text;

namespace SOC.GEN.CTR.Logging.Logger.Contracts
{
    /// <summary>
    /// Core contract for strucured logging. All logging providers must implement this interface
    /// </summary>
    public interface IStructuredLog
    {
        /// <summary>
        /// Debug level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Debug(string message, params object[] propertyValues);

        /// <summary>
        /// Debug message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Debug(Exception exception, string message, params object[] propertyValues);

        /// <summary>
        /// Error level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Error(string message, params object[] propertyValues);

        /// <summary>
        /// Error level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Error(Exception exception, string message, params object[] propertyValues);

        /// <summary>
        /// Fatal level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Fatal(string message, params object[] propertyValues);

        /// <summary>
        /// Fatal level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Fatal(Exception exception, string message, params object[] propertyValues);

        /// <summary>
        /// Information level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Information(string message, params object[] propertyValues);

        /// <summary>
        /// Information level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Information(Exception exception, string message, params object[] propertyValues);

        /// <summary>
        /// Warning level message logging
        /// </summary>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Warning(string message, params object[] propertyValues);

        /// <summary>
        /// Warning level message logging
        /// </summary>
        /// <param name="exception">Exception, if any to be logged</param>
        /// <param name="message">Message or message template</param>
        /// <param name="propertyValues">Properties for any context and template values</param>
        void Warning(Exception exception, string message, params object[] propertyValues);
    }
}
