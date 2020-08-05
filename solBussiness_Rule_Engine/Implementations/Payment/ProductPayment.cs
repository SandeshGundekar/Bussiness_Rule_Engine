using Implementations.PackingSlip;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Payment
{
    public class ProductPayment : IPayment
    {
        ICommission _commissionPayment;
        IPackingSlip _packingSlip = new ProductPackingSlip();

        public ProductPayment(ICommission commissionPayment)
        {
            _commissionPayment = commissionPayment;

        }

        public PaymentResult MakePayment(Product pProduct)
        {
            PaymentResult paymentResult = new PaymentResult();
            paymentResult.ProductPackingSlip = _packingSlip.GeneratePackingSlip(pProduct);
            paymentResult.AgentCommission = _commissionPayment.GenerateCommission(pProduct);
            return paymentResult;
        }
    }
}
