﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PayPal.Api;
using RentAnUmpireWebApi.Helper;
using RentAnUmpireWebApi.RentalUmpire.Services;

namespace RentAnUmpireWebApi.Controllers
{
    // https://github.com/pedropaf/paypal-integration/tree/master/src/Paypal-Integration
    public class PayPalController : Controller
    {
        #region Single PayPal Payment
        public IActionResult CreatePayment()
        {
            var payment = PayPalPaymentService.CreatePayment(GetBaseUrl(), "sale");

            return Redirect(payment.GetApprovalUrl());
        }

        public IActionResult PaymentCancelled()
        {
            // TODO: Handle cancelled payment
            return RedirectToAction("Error");
        }

        public IActionResult PaymentSuccessful(string paymentId, string token, string PayerID)
        {
            // Execute Payment
            var payment = PayPalPaymentService.ExecutePayment(paymentId, PayerID);

            return Ok();
        }
        #endregion

        #region Authorize PayPal Payment
        public IActionResult AuthorizePayment()
        {
            var payment = PayPalPaymentService.CreatePayment(GetBaseUrl(), "authorize");

            return Redirect(payment.GetApprovalUrl());
        }

        public IActionResult AuthorizeSuccessful(string paymentId, string token, string PayerID)
        {
            // Capture Payment
            var capture = PayPalPaymentService.CapturePayment(paymentId);

            return Ok();
        }
        #endregion

        #region Billing Plan and subscription
        // Create a billing plan and subscribe to it
        public IActionResult Subscribe()
        {
            var plan = PayPalSubscriptionsService.CreateBillingPlan("Tuts+ Plan", "Test plan for this article", GetBaseUrl());

            var subscription = PayPalSubscriptionsService.CreateBillingAgreement(plan.id,
                new PayPal.Api.ShippingAddress
                {
                    city = "London",
                    line1 = "line 1",
                    postal_code = "SW1A 1AA",
                    country_code = "GB"
                }, "Pedro Alonso", "Tuts+", DateTime.Now);

            return Redirect(subscription.GetApprovalUrl());
        }

        public IActionResult SubscribeSuccess(string token)
        {
            // Execute approved agreement
            PayPalSubscriptionsService.ExecuteBillingAgreement(token);

            return Ok();
        }

        public IActionResult SubscribeCancel(string token)
        {
            // TODO: Handle cancelled payment
            return RedirectToAction("Error");
        }
        #endregion

        #region WebHooks
        public IActionResult Webhook()
        {
            // The APIContext object can contain an optional override for the trusted certificate.
            var apiContext = PayPalConfiguration.GetAPIContext();

            // Get the received request's headers
            var requestheaders = HttpContext.Request.Headers;

            // Get the received request's body
            var requestBody = string.Empty;
            using (var reader = new System.IO.StreamReader(HttpContext.Request.Body))
            {
                requestBody = reader.ReadToEnd();
            }

            dynamic jsonBody = JObject.Parse(requestBody);
            string webhookId = jsonBody.id;
            var ev = WebhookEvent.Get(apiContext, webhookId);

            // We have all the information the SDK needs, so perform the validation.
            // Note: at least on Sandbox environment this returns false.
            // var isValid = WebhookEvent.ValidateReceivedEvent(apiContext, ToNameValueCollection(requestheaders), requestBody, webhookId);

            switch (ev.event_type)
            {
                case "PAYMENT.CAPTURE.COMPLETED":
                    // Handle payment completed
                    break;
                case "PAYMENT.CAPTURE.DENIED":
                    // Handle payment denied
                    break;
                // Handle other webhooks
                default:
                    break;
            }

            return Ok();
        }
        #endregion

        public string GetBaseUrl()
        {
            return Request.Scheme + "://" + Request.Host;
        }

        public NameValueCollection ToNameValueCollection(IHeaderDictionary dict)
        {
            var nameValueCollection = new NameValueCollection();

            foreach (var kvp in dict)
            {
                string value = null;
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    value = kvp.Value.ToString();
                }

                nameValueCollection.Add(kvp.Key.ToString(), value);
            }

            return nameValueCollection;
        }
    }
}