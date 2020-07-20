using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuleEngineAPI.Application.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Response
    {
        /// <summary>
        /// 
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorCode { get; set; }
    }
}
