using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services;

namespace UnitTestProject
{
    [TestClass]
    public class PaymentServiceTest
    {

        [TestMethod]
        public void TestBookPayment()
        {
            Product product = new Product() { Agent = 1, Amount = 1000.00, Category = 1, ProductId = 1, ProductType = "Books", ProductName = "Book 1"};


            var mockComm = new Mock<ICommission>();
            mockComm.Setup(x => x.GenerateCommission(product)).Returns(true);

            var mockMember = new Mock<IMembership>();
            PaymentService paymentService = new PaymentService(mockComm.Object, mockMember.Object);

            var result = paymentService.MakePayment(product);
            Assert.IsTrue(result.AgentCommission == true);
            Assert.IsTrue(result.RoyaltiPackingSlip == true);

            Assert.IsTrue(result.VideoPackingSlip == false);
            Assert.IsTrue(result.MembershipActivated == false);
            Assert.IsTrue(result.MembershipUpgraded == false);
            Assert.IsTrue(result.NotificationSent == false);
        }

        [TestMethod]
        public void TestProductPayment()
        {
            Product product = new Product() { Agent = 1, Amount = 1000.00, Category = 1, ProductId = 1, ProductType = "", ProductName = "Toy 1"};

            var mockComm = new Mock<ICommission>();
            mockComm.Setup(x => x.GenerateCommission(product)).Returns(true);

            var mockMember = new Mock<IMembership>();
            PaymentService paymentService = new PaymentService(mockComm.Object, mockMember.Object);

            var result = paymentService.MakePayment(product);
            Assert.IsTrue(result.AgentCommission == true);
            Assert.IsTrue(result.RoyaltiPackingSlip == false);
            Assert.IsTrue(result.ProductPackingSlip == true);

            Assert.IsTrue(result.VideoPackingSlip == false);
            Assert.IsTrue(result.MembershipActivated == false);
            Assert.IsTrue(result.MembershipUpgraded == false);
            Assert.IsTrue(result.NotificationSent == false);
        }

        [TestMethod]
        public void TestVideoPayment()
        {
            Product product = new Product() { Agent = 1, Amount = 2000.00, Category = 2, ProductId = 1, ProductType = "", ProductName = "Video" };
            var mockComm = new Mock<ICommission>();
            mockComm.Setup(x => x.GenerateCommission(product)).Returns(true);

            var mockMember = new Mock<IMembership>();
            PaymentService paymentService = new PaymentService(mockComm.Object, mockMember.Object);

            var result = paymentService.MakePayment(product);
            Assert.IsTrue(result.AgentCommission == false);
            Assert.IsTrue(result.RoyaltiPackingSlip == false);
            Assert.IsTrue(result.ProductPackingSlip == false);
            Assert.IsTrue(result.VideoPackingSlip == false);

            Assert.IsTrue(result.MembershipActivated == false);
            Assert.IsTrue(result.MembershipUpgraded == false);
            Assert.IsTrue(result.NotificationSent == false);
        }

        [TestMethod]
        public void TestVideoPaymentForSki()
        {
            Product product = new Product() { Agent = 1, Amount = 2000.00, Category = 2, ProductId = 1, ProductType = "", ProductName = "Learning To Ski" };
            var mockComm = new Mock<ICommission>();
            mockComm.Setup(x => x.GenerateCommission(product)).Returns(true);

            var mockMember = new Mock<IMembership>();
            PaymentService paymentService = new PaymentService(mockComm.Object, mockMember.Object);

            var result = paymentService.MakePayment(product);
            Assert.IsTrue(result.AgentCommission == false);
            Assert.IsTrue(result.RoyaltiPackingSlip == false);
            Assert.IsTrue(result.ProductPackingSlip == false);
            Assert.IsTrue(result.VideoPackingSlip == true);

            Assert.IsTrue(result.MembershipActivated == false);
            Assert.IsTrue(result.MembershipUpgraded == false);
            Assert.IsTrue(result.NotificationSent == false);
        }

        [TestMethod]
        public void TestNewMembershipPayment()
        {
            Product product = new Product() { Agent = 1, Amount = 2000.00, Category = 3, ProductId = 1, ProductType = "New", ProductName = "" };
            var mockComm = new Mock<ICommission>();
            //mockComm.Setup(x => x.GenerateCommission(cart)).Returns(true);

            var mockMember = new Mock<IMembership>();
            mockMember.Setup(x => x.ActivateMembership()).Returns(true);
            PaymentService paymentService = new PaymentService(mockComm.Object, mockMember.Object);

            var result = paymentService.MakePayment(product);
            Assert.IsTrue(result.AgentCommission == false);
            Assert.IsTrue(result.RoyaltiPackingSlip == false);
            Assert.IsTrue(result.ProductPackingSlip == false);
            Assert.IsTrue(result.VideoPackingSlip == false);
            Assert.IsTrue(result.MembershipActivated == true);
            Assert.IsTrue(result.MembershipUpgraded == false);
            Assert.IsTrue(result.NotificationSent == true);
        }
        [TestMethod]
        public void TestUpgradeMembershipPayment()
        {
            Product product = new Product() { Agent = 1, Amount = 2000.00, Category = 3, ProductId = 1, ProductType = "Upgrade", ProductName = "" };
            var mockComm = new Mock<ICommission>();
            //mockComm.Setup(x => x.GenerateCommission(cart)).Returns(false);

            var mockMember = new Mock<IMembership>();
            mockMember.Setup(x => x.UpgradeMembership()).Returns(true);
            PaymentService paymentService = new PaymentService(mockComm.Object, mockMember.Object);

            var result = paymentService.MakePayment(product);
            Assert.IsTrue(result.AgentCommission == false);
            Assert.IsTrue(result.RoyaltiPackingSlip == false);
            Assert.IsTrue(result.ProductPackingSlip == false);
            Assert.IsTrue(result.VideoPackingSlip == false);
            Assert.IsTrue(result.MembershipActivated == false);
            Assert.IsTrue(result.MembershipUpgraded == true);
            Assert.IsTrue(result.NotificationSent == true);
        }
    }
}
