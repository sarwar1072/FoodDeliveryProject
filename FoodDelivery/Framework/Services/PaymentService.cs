﻿using Framework.Entities;
using Framework.Model;
using Framework.UnitOfworks;
using Microsoft.Extensions.Options;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IOptions<RazorPayConfig> _razorPayConfig;
        private readonly RazorpayClient _client;

        private readonly IShoppingUnitOfWork _shopingUnitOfWork;
        //ICartRepository _cartRepo;
        public PaymentService(IOptions<RazorPayConfig> razorPayConfig, IShoppingUnitOfWork shopingUnitOfWork)
        {
            _razorPayConfig = razorPayConfig;
            _shopingUnitOfWork = shopingUnitOfWork;
           // _cartRepo = cartRepo;

            if (_client == null)
            {
                _client = new RazorpayClient(_razorPayConfig.Value.Key, _razorPayConfig.Value.Secret);
            }
        }

        public string CreateOrder(decimal amount, string currency, string receipt)
        {
            try
            {
                Dictionary<string, object> options = new Dictionary<string, object>();

                options.Add("amount", amount);
                options.Add("currency", currency);
                options.Add("receipt", receipt);
                options.Add("payment_capture", 1);
                Razorpay.Api.Order orderResponse = _client.Order.Create(options);
                return orderResponse["id"].ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string CapturePayment(string paymentId, string orderId)
        {
            if (!String.IsNullOrWhiteSpace(paymentId) && !String.IsNullOrWhiteSpace(orderId))
            {
                try
                {
                    Payment payment = _client.Payment.Fetch(paymentId);
                    // This code is for capture the payment 
                    Dictionary<string, object> options = new Dictionary<string, object>();
                    options.Add("amount", payment.Attributes["amount"]);
                    options.Add("currency", payment.Attributes["currency"]);
                    Payment paymentCaptured = payment.Capture(options);
                    return paymentCaptured.Attributes["status"];
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
            return null;
        }

        public Payment GetPaymentDetails(string paymentId)
        {
            if (!String.IsNullOrWhiteSpace(paymentId))
            {
                return _client.Payment.Fetch(paymentId);
            }
            return null;
        }

        public bool VerifySignature(string signature, string orderId, string paymentId)
        {
            string payload = string.Format("{0}|{1}", orderId, paymentId);
            string secret = RazorpayClient.Secret;
            string actualSignature = getActualSignature(payload, secret);
            return actualSignature.Equals(signature);
        }

        private static string getActualSignature(string payload, string secret)
        {
            byte[] secretBytes = StringEncode(secret);
            HMACSHA256 hashHmac = new HMACSHA256(secretBytes);
            var bytes = StringEncode(payload);

            return HashEncode(hashHmac.ComputeHash(bytes));
        }

        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        public int SavePaymentDetails(PaymentDetails model)
        {
            _shopingUnitOfWork.PaymentDetailsRepository.Add(model);
            var cart = _shopingUnitOfWork.CartRepository.GetById(model.CartId);
            cart.IsActive = false;

          return  _shopingUnitOfWork.SaveChanges();

        }
    }
}
