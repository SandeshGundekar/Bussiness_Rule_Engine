using Factory;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PaymentService
    {
        ICommission _commission;
        IMembership _membership;
        public PaymentService(ICommission commission, IMembership membership)
        {
            _commission = commission;
            _membership = membership;
        }
        public PaymentResult MakePayment(Product pProduct)
        {
            try
            {
                NotificationFactory notificationFactory = new NotificationFactory();
                PaymentFactory paymentFactory = new PaymentFactory(_commission, _membership, notificationFactory.CreateNotification(NotificationFactory.enmNotificationType.Email));
                IPayment payment = paymentFactory.CreatePayment(pProduct);
                return payment.MakePayment(pProduct);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
