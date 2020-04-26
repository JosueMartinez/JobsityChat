using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsityChat.Models
{
    public class MessageViewModel
    {
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public string User { get; set; }
    }
}
