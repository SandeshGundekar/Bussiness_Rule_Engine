using Implementations.PackingSlip;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Payment
{
    public class VideoPayment : IPayment
    {
        IPackingSlip _packingSlip = new VideoPackingSlip();
        public PaymentResult MakePayment(Product pProduct)
        {
            PaymentResult paymentResult = new PaymentResult();
            paymentResult.VideoPackingSlip = _packingSlip.GeneratePackingSlip(pProduct);
            return paymentResult;
        }
    }
}
