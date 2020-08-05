using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.PackingSlip
{
    public class RoyaltyPackingSlip : IPackingSlip
    {
        IPackingSlip packingSlip = new ProductPackingSlip();
        public bool GeneratePackingSlip(Product pProduct)
        {
            packingSlip.GeneratePackingSlip(pProduct);
            Console.WriteLine("Generate Duplicate Packing Slip for Royalty");
            return true;
        }
    }
}
