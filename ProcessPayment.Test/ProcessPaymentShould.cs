using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProcessPayment.API.Controllers;
using ProcessPayment.Commons;
using ProcessPayment.Core;
using ProcessPayment.Core.Interfaces;
using ProcessPayment.Data;
using ProcessPayment.Dto;
using ProcessPayment.Models;
using System;
using System.Threading.Tasks;

namespace ProcessPayment.Test
{
    public class ProcessPaymentShould
    {
        private PaymentController _paymentController;
        private Mock<IPaymentService> _paymentServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {

            _paymentServiceMock = new Mock<IPaymentService>();
            _mapperMock = new Mock<IMapper>();

            _paymentController = new PaymentController(_paymentServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public void ShouldReturnResponse200()
        {
            PaymentDetailsDto incomingPaymentDetailsMock = new PaymentDetailsDto
            {
                CreditCardNumber = "5429239838398598",
                CardHolder = "Jane Doe",
                Amount = 12.23m,
                ExpirationDate = DateTime.Parse("2023-07-29T21:58:39"),
            };

           _paymentServiceMock.Setup(p => p.AddPayment(It.IsAny<Payment>())).ReturnsAsync(true);
            var result = _paymentController.ProcessPayment(incomingPaymentDetailsMock).Result;

            Assert.True(result is OkObjectResult);
        }

        [Test]
        public void ShouldReturnResponse502()
        {
            PaymentDetailsDto incomingPaymentDetailsMock = new PaymentDetailsDto
            {
                CreditCardNumber = "5429239838398598",
                CardHolder = "Jane Doe",
                Amount = 12.23m,
                ExpirationDate = DateTime.Parse("2023-07-29T21:58:39"),
            };

            _paymentServiceMock.Setup(p => p.AddPayment(It.IsAny<Payment>())).ReturnsAsync(false);

            var result = _paymentController.ProcessPayment(incomingPaymentDetailsMock).Result;

            Assert.True(result is BadRequestObjectResult);
        }
    }
}
