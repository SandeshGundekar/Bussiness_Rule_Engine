using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// 1 - Physical
        /// 2 - Virtual/Video
        /// 3 - Membership
        /// </summary>
        public Int16 Category { get; set; } //1 - Physical/ 2 - Video/ 3 -Membership
        /// <summary>
        /// Type Of Product
        /// Books 
        /// If Category is Membership then New or Upgrade
        /// </summary>
        public string ProductType { get; set; } //Books /If Membership - New/ Upgrade  
        
        public int Agent { get; set; }
        public double Amount { get; set; }
    }
}
