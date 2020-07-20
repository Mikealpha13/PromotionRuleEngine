using MediatR;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.Options;
using RuleEngine.Domain.Rule;
using RuleEngineAPI.Application.ViewModels.Promotion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RuleEngineAPI.Application.Commands.Promotion
{

    /// <summary>
    /// This handler is used to perform business logic
    /// </summary>
    public class PromotionRuleCommandHandler : IRequestHandler<PromotionRuleCommand, PromotionResponseViewModel>
    {

        private readonly IOptions<RuleEntity> _ruleConfiguration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleConfiguration"></param>
        public PromotionRuleCommandHandler(IOptions<RuleEntity>ruleConfiguration)
        {
            _ruleConfiguration = ruleConfiguration ?? throw new ArgumentNullException(nameof(ruleConfiguration));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PromotionResponseViewModel> Handle(PromotionRuleCommand request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {

                int price = 0;
                List<string> ComboPacks = new List<string>();
                request.PurchaseRequest.PurchasedPoduct.ForEach(z =>
                {
                    var productRule = _ruleConfiguration.Value.PromotionRules.FirstOrDefault(x => x.Id == z.CodeName);

                    if (productRule.CombinationIndicator && request.PurchaseRequest.PurchasedPoduct.Any(i => i.CodeName == productRule.CombinationId))
                    {
                        if (!ComboPacks.Any(k => k == productRule.Id))
                        {
                            price = price + productRule.CombinationPrice;
                           
                        }
                       
                       ComboPacks.Add(productRule.CombinationId);
                       

                    }
                    else if (productRule.PercentageIndicator && productRule.Units == z.Quantity)
                    {


                    }
                    else if (!productRule.PercentageIndicator && productRule.Units == z.Quantity)
                    {
                        price = price + productRule.DisocuntedPrice;
                    }
                    else if (!productRule.PercentageIndicator && productRule.Units < z.Quantity)
                    {
                        int quotient = z.Quantity / productRule.Units;
                        int reminder = z.Quantity % productRule.Units;

                        price = price + (productRule.DisocuntedPrice*quotient)+(productRule.OrignalPricePerUnit*reminder);
                    }
                    else
                    {
                        price = price + (productRule.OrignalPricePerUnit * z.Quantity);
                    }

                });

                return new PromotionResponseViewModel() { promotionalPrice = price, RequestId = request.PurchaseRequest.RequestId, ErrorCode = string.Empty, ErrorMessage = string.Empty };


            });
            

          
        }
    }
}
