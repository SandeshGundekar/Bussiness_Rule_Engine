using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.PackingSlip
{
    public class VideoPackingSlip : IPackingSlip
    {
        public bool GeneratePackingSlip(Product pProduct)
        {
            if (pProduct.ProductName == "Learning To Ski")
            {
                Console.WriteLine("Added 'First Aid' Video in packing list");
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
