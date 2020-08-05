using Implementations.Notification;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class NotificationFactory
    {
        public enum enmNotificationType
        {
            Email=1//,SMS=2
        }

        public INotification CreateNotification(enmNotificationType notificationType )
        {
            INotification notification = null;
            switch (notificationType)
            {
                case enmNotificationType.Email:
                    notification = new EmailNotification();
                    break;
                
                default:
                    break;
            }
            return notification;
        }
    }
}
