﻿using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Payment
{
    public class UpgradeMembershipPayment : IPayment
    {
        public PaymentResult MakePayment(Product pProduct)
        {
            throw new NotImplementedException();
        }
    }
}