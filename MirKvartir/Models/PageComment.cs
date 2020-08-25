using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirKvartir.Models
{
    public class PageComment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int Level { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? Parent { get; set; }
    }
}
