﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPayment
    {
        PaymentResult MakePayment(Product pProduct);
    }
}
