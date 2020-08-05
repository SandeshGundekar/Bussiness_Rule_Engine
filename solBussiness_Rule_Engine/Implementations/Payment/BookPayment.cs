using Implementations.PackingSlip;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Payment
{
    public class BookPayment : IPayment
    {
        ICommission _commissionPayment;
        IPackingSlip _packingSlip = new RoyaltyPackingSlip();

        public BookPayment(ICommission commissionPayment)
        {
            _commissionPayment = commissionPayment;

        }

        public PaymentResult MakePayment(Product pProduct)
        {
            PaymentResult paymentResult = new PaymentResult();
            paymentResult.RoyaltiPackingSlip = _packingSlip.GeneratePackingSlip(pProduct);
            paymentResult.AgentCommission = _commissionPayment.GenerateCommission(pProduct);
            return paymentResult;

        }
    }
}
