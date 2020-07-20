using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RuleEngineAPI.Application.Commands.Promotion
{

    /// <summary>
    /// This handler is used to perform business logic
    /// </summary>
    public class PromotionRuleCommandHandler : IRequestHandler<PromotionRuleCommand, object>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<object> Handle(PromotionRuleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
