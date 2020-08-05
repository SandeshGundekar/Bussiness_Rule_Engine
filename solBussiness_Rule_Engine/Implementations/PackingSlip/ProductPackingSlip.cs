using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.PackingSlip
{
    public class ProductPackingSlip : IPackingSlip
    {
        public bool GeneratePackingSlip(Product pProduct)
        {
            Console.WriteLine("Generate Product Packing Slip");
            return true;
        }
    }
}
