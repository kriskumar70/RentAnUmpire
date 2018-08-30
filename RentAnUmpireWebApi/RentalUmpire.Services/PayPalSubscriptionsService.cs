﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayPal.Api;
using RentAnUmpireWebApi.Helper;

namespace RentAnUmpireWebApi.RentalUmpire.Services
{
    public static class PayPalSubscriptionsService
    {
        public static Plan CreateBillingPlan(string name, string description, string baseUrl)
        {
            var returnUrl = baseUrl + "/Home/SubscribeSuccess";
            var cancelUrl = baseUrl + "/Home/SubscribeCancel";

            // Plan Details
            var plan = CreatePlanObject("Test Plan", "Plan for Tuts+", returnUrl, cancelUrl,
                PlanInterval.Month, 1, (decimal)19.90, trial: true, trialLength: 1, trialPrice: 0);

            // PayPal Authentication tokens
            var apiContext = PayPalConfiguration.GetAPIContext();

            // Create plan
            plan = plan.Create(apiContext);

            // Activate the plan
            var patchRequest = new PatchRequest()
            {
                new Patch()
                {
                    op = "replace",
                    path = "/",
                    value = new Plan() { state = "ACTIVE" }
                }
            };
            plan.Update(apiContext, patchRequest);

            return plan;
        }

        public static void UpdateBillingPlan(string planId, string path, object value)
        {
            // PayPal Authentication tokens
            var apiContext = PayPalConfiguration.GetAPIContext();

            // Retrieve Plan
            var plan = Plan.Get(apiContext, planId);

            // Activate the plan
            var patchRequest = new PatchRequest()
            {
                new Patch()
                {
                    op = "replace", // Only the 'replace' operation is supported when updating billing plans.
                    path = path,
                    value = value
                }
            };
            plan.Update(apiContext, patchRequest);
        }

        public static void DeactivateBillingPlan(string planId)
        {
            UpdateBillingPlan(
                planId: planId,
                path: "/",
                value: new Plan { state = "INACTIVE" });
        }

        public static Agreement CreateBillingAgreement(string planId, ShippingAddress shippingAddress,
            string name, string description, DateTime startDate)
        {
            // PayPal Authentication tokens
            var apiContext = PayPalConfiguration.GetAPIContext();

            var agreement = new Agreement()
            {
                name = name,
                description = description,
                start_date = startDate.ToString("yyyy-MM-ddTHH:mm:ss") + "Z",
                payer = new Payer() { payment_method = "paypal" },
                plan = new Plan() { id = planId },
                shipping_address = shippingAddress
            };

            var createdAgreement = agreement.Create(apiContext);
            return createdAgreement;
        }

        public static void ExecuteBillingAgreement(string token)
        {
            // PayPal Authentication tokens
            var apiContext = PayPalConfiguration.GetAPIContext();

            var agreement = new Agreement() { token = token };
            var executedAgreement = agreement.Execute(apiContext);
        }

        public static void SuspendBillingAgreement(string agreementId)
        {
            var apiContext = PayPalConfiguration.GetAPIContext();

            var agreement = new Agreement() { id = agreementId };
            agreement.Suspend(apiContext, new AgreementStateDescriptor()
            { note = "Suspending the agreement" });
        }

        public static void ReactivateBillingAgreement(string agreementId)
        {
            var apiContext = PayPalConfiguration.GetAPIContext();

            var agreement = new Agreement() { id = agreementId };
            agreement.ReActivate(apiContext, new AgreementStateDescriptor()
            { note = "Reactivating the agreement" });
        }

        public static void CancelBillingAgreement(string agreementId)
        {
            var apiContext = PayPalConfiguration.GetAPIContext();

            var agreement = new Agreement() { id = agreementId };
            agreement.Cancel(apiContext, new AgreementStateDescriptor()
            { note = "Cancelling the agreement" });
        }

        #region Helpers
        /// <summary>
        /// Helper method for getting a currency amount.
        /// </summary>
        /// <param name="value">The value for the currency object.</param>
        /// <returns></returns>
        private static Currency GetCurrency(string value)
        {
            return new Currency() { value = value, currency = "USD" };
        }

        private static class PlanType
        {
            /// <summary>
            /// Use Fixed when you want to create a billing plan with a fixed number of payments (cycles)
            /// </summary>
            public static string Fixed { get { return "fixed"; } }

            /// <summary>
            /// Use Infinite and set cycles to 0 for a billing plan that is active until it's manually cancelled
            /// </summary>
            public static string Infinite { get { return "infinite"; } }
        }

        private static class PlanInterval
        {
            public static string Week { get { return "Week"; } }
            public static string Day { get { return "Day"; } }
            public static string Month { get { return "Month"; } }
            public static string Year { get { return "Year"; } }
        }

        public static Plan CreatePlanObject(string planName, string planDescription, string returnUrl, string cancelUrl,
            string frequency, int frequencyInterval, decimal planPrice,
            decimal shippingAmount = 0, decimal taxPercentage = 0, bool trial = false, int trialLength = 0, decimal trialPrice = 0)
        {
            // Define the plan and attach the payment definitions and merchant preferences.
            // More Information: https://developer.paypal.com/docs/rest/api/payments.billing-plans/
            return new Plan
            {
                name = planName,
                description = planDescription,
                type = PlanType.Fixed,

                // Define the merchant preferences.
                // More Information: https://developer.paypal.com/webapps/developer/docs/api/#merchantpreferences-object
                merchant_preferences = new MerchantPreferences()
                {
                    setup_fee = GetCurrency("1"),
                    return_url = returnUrl,
                    cancel_url = cancelUrl,
                    auto_bill_amount = "YES",
                    initial_fail_amount_action = "CONTINUE",
                    max_fail_attempts = "0"
                },
                payment_definitions = GetPaymentDefinitions(trial, trialLength, trialPrice, frequency, frequencyInterval, planPrice, shippingAmount, taxPercentage)
            };
        }

        private static List<PaymentDefinition> GetPaymentDefinitions(bool trial, int trialLength, decimal trialPrice,
            string frequency, int frequencyInterval, decimal planPrice, decimal shippingAmount, decimal taxPercentage)
        {
            var paymentDefinitions = new List<PaymentDefinition>();

            if (trial)
            {
                // Define a trial plan that will charge 'trialPrice' for 'trialLenght'
                // After that, the standard plan will take over.
                paymentDefinitions.Add(
                    new PaymentDefinition()
                    {
                        name = "Trial",
                        type = "TRIAL",
                        frequency = frequency,
                        frequency_interval = frequencyInterval.ToString(),
                        amount = GetCurrency(trialPrice.ToString()),
                        cycles = trialLength.ToString(),
                        charge_models = GetChargeModels(trialPrice, shippingAmount, taxPercentage)
                    });
            }

            // Define the standard payment plan. It will represent a 'frequency' (monthly, etc)
            // plan for 'planPrice' that charges 'planPrice' (once a month) for #cycles.
            var regularPayment = new PaymentDefinition
            {
                name = "Standard Plan",
                type = "REGULAR",
                frequency = frequency,
                frequency_interval = frequencyInterval.ToString(),
                amount = GetCurrency(planPrice.ToString()),
                // > NOTE: For `IFNINITE` type plans, `cycles` should be 0 for a `REGULAR` `PaymentDefinition` object.
                cycles = "11",
                charge_models = GetChargeModels(trialPrice, shippingAmount, taxPercentage)
            };
            paymentDefinitions.Add(regularPayment);

            return paymentDefinitions;
        }

        private static List<ChargeModel> GetChargeModels(decimal planPrice, decimal shippingAmount, decimal taxPercentage)
        {
            // Create the Billing Plan
            var chargeModels = new List<ChargeModel>();
            if (shippingAmount > 0)
            {
                chargeModels.Add(new ChargeModel()
                {
                    type = "SHIPPING",
                    amount = GetCurrency(shippingAmount.ToString())
                });
            }
            if (taxPercentage > 0)
            {
                chargeModels.Add(new ChargeModel()
                {
                    type = "TAX",
                    amount = GetCurrency(String.Format("{0:f2}", planPrice * taxPercentage / 100))
                });
            }

            return chargeModels;
        }
        #endregion
    }
}