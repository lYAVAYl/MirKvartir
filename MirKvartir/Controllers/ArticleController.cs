using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirKvartir.Models;

namespace MirKvartir.Controllers
{
    public class ArticleController : Controller
    {
        IArticleRepository repoArticle;
        IPageCommentRepository repoComments;
        public ArticleController(IArticleRepository rArticle, IPageCommentRepository rComments)
        {
            repoArticle = rArticle;
            repoComments = rComments;
        }

        public ActionResult Index()
        {
            return View(repoArticle.GetArticles());
        }

        [HttpGet]
        public ActionResult ShowArticle(int id)
        {
            Article article = repoArticle.Get(id);
            if (article != null)
            {
                CommentListModel commentList = new CommentListModel()
                {
                    Comments = repoComments.GetComments(id).ToArray().Select(x=>new PageComment()
                    {
                        CommentId = x.CommentId,
                        Level = x.Level, 
                        Parent = x.Parent,
                        Text = x.Text,
                        UserId = x.UserId,
                        UserName = x.UserName
                    })
                };

                ViewData["Comments"] = commentList;

                return View(article);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult ShowArticle()
        {


            return null;
        }
    }
}
