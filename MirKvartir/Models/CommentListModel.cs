using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirKvartir.Models
{
    public class CommentListModel
    {
        public int? Seed { get; set; }
        public IEnumerable<PageComment> Comments { get; set; }
    }
}
