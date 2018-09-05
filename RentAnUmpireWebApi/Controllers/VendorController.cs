using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentAnUmpireWebApi.ViewModels;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace RentAnUmpireWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Vendor")]
    public class VendorController : Controller
    {
        [HttpPost]
        [Route("sendGrid")]
        public async Task<IActionResult> SendNotification(EmailViewModel emailViewModel)
        {
            // Retrieve the API key from the environment variables. See the project README for more info about setting this up.
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");

            var client = new SendGridClient(apiKey);

            // Send a Single Email using the Mail Helper
            var from = new EmailAddress(emailViewModel.FromEmail, emailViewModel.FromName);
            var subject = emailViewModel.Subject;
            var to = new EmailAddress(emailViewModel.ToEmail, emailViewModel.ToName);
            var plainTextContent = emailViewModel.Message;
            var htmlContent = "DCL - Rent An Umpire Team.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
            return Ok(response);
        }

        [HttpPost]
        [Route("sentSms")]
        public IActionResult SendSmsNotification(SmsViewModel smsViewModel)
        {
            // Retrieve the API key from the environment variables. See the project README for more info about setting this up.

            string acccountSid = ConfigurationManager.AppSetting["Tvillio:accountSid"];
            string authToken = ConfigurationManager.AppSetting["Tvillio:authToken"];

            TwilioClient.Init(acccountSid, authToken);

            var message = MessageResource.Create(
                body: smsViewModel.Message,
                from: new PhoneNumber(smsViewModel.FromNumber),
                to: new PhoneNumber(smsViewModel.ToNumber)
            );
            return Ok(message.Sid);
        }
    }
}