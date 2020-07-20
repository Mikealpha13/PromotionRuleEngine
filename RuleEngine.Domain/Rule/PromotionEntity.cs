using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngine.Domain.Rule
{
    public class PromotionEntity
    {
        public string Id { get; set; }
        public int Units { get; set; }
        public int DisocuntedPrice { get; set; }
        public int OrignalPricePerUnit { get; set; }
        public bool PercentageIndicator { get; set; }
        public int PercentageUnit { get; set; }
        public bool CombinationIndicator { get; set; }
        public string CombinationId { get; set; }
        public int CombinationPrice { get; set; }
    }
}
