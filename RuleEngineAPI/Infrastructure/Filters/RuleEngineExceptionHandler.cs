using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuleEngineAPI.Infrastructure.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class RuleEngineExceptionHandler: ExceptionFilterAttribute
    {
       
        private ILogger<RuleEngineExceptionHandler> _Logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public RuleEngineExceptionHandler(ILogger<RuleEngineExceptionHandler> logger)
        {
            _Logger = logger;
        }

        // ...
    }
}

