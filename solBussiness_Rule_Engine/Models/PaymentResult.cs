using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PaymentResult
    {
        public bool ProductPackingSlip { get; set; }
        public bool RoyaltiPackingSlip { get; set; }
        public bool VideoPackingSlip { get; set; }
        public bool NotificationSent { get; set; }
        public bool AgentCommission { get; set; }
        public bool MembershipActivated { get; set; }
        public bool MembershipUpgraded { get; set; }
    }
}
