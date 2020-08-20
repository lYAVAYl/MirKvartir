using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MirKvartir.Models
{
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
        [MinLength(1, ErrorMessage = "Введите хоть что-то...")]
        public string Text { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
