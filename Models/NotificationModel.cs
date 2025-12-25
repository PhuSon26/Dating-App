using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN.Models
{
    public class NotificationModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
        public string DataID { get; set; }
        public string Timestamp { get; set; }
    }
}
