using Implementations.Payment;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class PaymentFactory
    {
        ICommission _commission;
        IMembership _membership;
        INotification _notification;
        public PaymentFactory(ICommission commissionPayment, IMembership membership,INotification notification)
        {
            _commission = commissionPayment;
            _membership = membership;
            _notification = notification;
        }
        enum enmCategory
        {
            Physical = 1,
            Video = 2,
            Membership = 3
        }

        public IPayment CreatePayment(Product pProduct)
        {
            IPayment payment = null;
            switch (pProduct.Category)
            {
                case (Int16)enmCategory.Physical:
                    if (pProduct.ProductType == "Books")
                    {
                        payment = new BookPayment(_commission);
                    }
                    else
                    {
                        payment = new ProductPayment(_commission);
                    }
                    break;
                case (Int16)enmCategory.Membership:
                    if (pProduct.ProductType == "New")
                    {
                        payment = new NewMembershipPayment(_membership, _notification);
                    }
                    else
                    {
                        payment = new UpgradeMembershipPayment(_membership, _notification);
                    }
                    break;
                case (Int16)enmCategory.Video:
                    payment = new VideoPayment();
                    break;

            }
            return payment;
        }
    }
}
