using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RentAnUmpireWebApi.ViewModels;
using SendGrid;
using SendGrid.Helpers.Mail;

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
    }
}