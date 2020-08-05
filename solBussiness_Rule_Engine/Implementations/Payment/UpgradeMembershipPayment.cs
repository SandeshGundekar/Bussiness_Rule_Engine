using Implementations.Notification;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Payment
{
    public class UpgradeMembershipPayment : IPayment
    {
        IMembership _membership;
        INotification _notification;
        public UpgradeMembershipPayment(IMembership membership, INotification notification)
        {
            _membership = membership;
            _notification = notification;
        }
        public PaymentResult MakePayment(Product pProduct)
        {
            PaymentResult paymentResult = new PaymentResult();
            paymentResult.MembershipUpgraded = _membership.UpgradeMembership();
            paymentResult.NotificationSent = _notification.SendNotification();
            return paymentResult;
        }
    }
}
