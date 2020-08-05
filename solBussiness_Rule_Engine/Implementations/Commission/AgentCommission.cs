using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Commission
{
    public class AgentCommission : ICommission
    {
        public bool GenerateCommission(Product pProduct)
        {
            Console.WriteLine("Generate Commision to Agent");
            return true;
        }
    }
}
