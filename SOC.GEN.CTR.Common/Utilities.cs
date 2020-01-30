using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOC.GEN.CTR.Common
{
    public class Utilities
    {
        public static IServiceCollection services { get; set; }

        /// <summary>
        /// Get instance of dependencies at run time
        /// </summary>
        /// <typeparam name="T">Typed parameter</typeparam>
        /// <returns>Instance of T</returns>
        public static T GetInstance<T>()
        {
            var currentResolver = services.BuildServiceProvider();

            if (currentResolver != null)
            {
                return (T)currentResolver.GetService(typeof(T));
            }
            return default(T);
        }
    }
}
