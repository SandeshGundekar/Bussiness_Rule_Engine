using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Notification
{
    public class EmailNotification : INotification
    {
        public bool SendNotification()
        {
            Console.WriteLine("Send Email");
            return true;
        }
    }
}
