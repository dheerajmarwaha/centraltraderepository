using System;
using System.Collections.Generic;
using System.Text;

namespace SOC.GEN.CTR.Logging.Logger.Contracts
{
    /// <summary>
    /// Contract for the database logging provider
    /// </summary>
    public interface IDatabaseLogger : IStructuredLog
    {
        /// <summary>
        /// Options for database logging
        /// </summary>
        DatabaseLogOptions LogOptions { get; set; }
    }
}
