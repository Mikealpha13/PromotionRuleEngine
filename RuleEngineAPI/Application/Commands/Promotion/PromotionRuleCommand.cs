using MediatR;
using RuleEngineAPI.Application.ViewModels.Promotion;
using RuleEngineAPI.Application.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuleEngineAPI.Application.Commands.Promotion
{
    /// <summary>
    /// This command is created to evaluate the promotion business requirements
    /// </summary>
    public class PromotionRuleCommand:IRequest<object>
    {
        /// <summary>
        /// 
        /// </summary>
        public PromotionRequestViewModel PurchaseRequest { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public PromotionRuleCommand(PromotionRequestViewModel request)
        {
            PurchaseRequest = request ?? throw new ArgumentNullException(nameof(request));
        }
    }
}
