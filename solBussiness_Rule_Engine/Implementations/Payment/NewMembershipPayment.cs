using Implementations.Notification;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementations.Payment
{
    public class NewMembershipPayment : IPayment
    {
        IMembership _membership;
        INotification _notification;
        public NewMembershipPayment(IMembership membership,INotification notification)
        {
            _membership = membership;
            _notification = notification;
        }
        public PaymentResult MakePayment(Product pProduct)
        {
            PaymentResult paymentResult = new PaymentResult();
            paymentResult.MembershipActivated = _membership.ActivateMembership();
            paymentResult.NotificationSent = _notification.SendNotification();
            return paymentResult;
        }
    }
}
