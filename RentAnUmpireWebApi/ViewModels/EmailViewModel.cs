using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RentAnUmpireWebApi.ViewModels
{
    public class EmailViewModel
    {

        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string Message { get; set; }
        List<Attachment> Attachments { get; set; }
        public string Subject { get; set; }

    }
    public class SmsViewModel
    {
        public string FromNumber { get; set; }
        public string ToNumber { get; set; }
        public string Message { get; set; }


    }
    public class Attachment
    {
        
        public string Content { get; set; }

        public string Type { get; set; }

     
        public string Filename { get; set; }

        public string Disposition { get; set; }

        public string ContentId { get; set; }
    }
}
