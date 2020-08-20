using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MirKvartir.Models
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [MinLength(1, ErrorMessage = "Пустой комментарий")]
        public string Text { get; set; }

        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public int? Parent { get; set; }

        public virtual Article Article { get; set; }
        public virtual ICollection<Comment> ParentComments { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual User User { get; set; }
    }
}
