using RuleEngineAPI.Application.ViewModels.Promotion;
using System.Collections.Generic;

namespace RuleEngineAPI.Application.ViewModels.Movies
{
    /// <summary>
    /// 
    /// </summary>
    public class PromotionRequestViewModel:Request
    {
        /// <summary>
        /// It contains the details the number of items purchased
        /// </summary>
        public List<Product> PurchasedPoduct { get; set; } = new List<Product>();
    }
}
