using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Membership
{
    public class CustomerMembership : IMembership
    {
        public bool ActivateMembership()
        {
            Console.WriteLine("Activate Membership");
            return true;
        }

        public bool UpgradeMembership()
        {
            Console.WriteLine("Upgrade Membership");
            return true;
        }
    }
}
