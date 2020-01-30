using System;
using System.Collections.Generic;
using System.Text;

namespace SOC.GEN.CTR.Logging.Logger.Contracts
{
    public interface IFlatFileLogger : IStructuredLog
    {
        /// <summary>
        /// Options for text file logging
        /// </summary>
        FileLogOptions LogOptions { get; set; }
    }
}
