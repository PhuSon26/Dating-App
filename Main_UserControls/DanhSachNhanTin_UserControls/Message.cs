using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN.Main_UserControls.DanhSachNhanTin_UserControls
{
    internal class Message
    {
        public string Id { get; set; }
        public string ConversationId { get; set; }
        public string SenderId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
