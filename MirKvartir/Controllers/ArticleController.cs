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
        IArticleRepository repo;
        public ArticleController(IArticleRepository r)
        {
            repo = r;
        }

        public ActionResult Index()
        {
            return View(repo.GetArticles());
        }

        [HttpGet]
        public ActionResult ShowArticle(int id)
        {
            Article article = repo.Get(id);
            if (article != null)
            {
                return View(article);
            }

            return NotFound();
        }
    }
}
