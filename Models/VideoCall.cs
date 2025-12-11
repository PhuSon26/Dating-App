using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace LOGIN.Models
{
    public class VideoCall
    {
        public string CallId { get; set; }
        public string CallerId { get; set; }
        public string CallerName { get; set; }
        public string ReceiverId { get; set; }
        public string Status { get; set; }
        public long Timestamp { get; set; }
        public string Offer { get; set; }
        public string Answer { get; set; }
    }
}
