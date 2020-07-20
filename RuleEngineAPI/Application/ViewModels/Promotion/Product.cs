using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuleEngineAPI.Application.ViewModels.Promotion
{

    /// <summary>
    /// This class contains the product details eligble for promotions
    /// </summary>
    public class Product
    {
        /// <summary>
        /// This property contains the value for product name
        /// </summary>
        public string CodeName { get; set; } = string.Empty;

        /// <summary>
        /// This property conatin the number of units to be purchased
        /// </summary>
        public int Quantity { get; set; } = 0;
    }
}
