using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MirKvartir.Models
{
    public interface IArticleRepository
    {
        Article Get(int id);
        public List<Article> GetArticles();
    }

    public class ArticleRepository:IArticleRepository
    {
        string connectionString = null;
        public ArticleRepository(string conn)
        {
            connectionString = conn;
        }

        public List<Article> GetArticles()
        {
            List<Article> articles;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                articles = db.Query<Article>("GetArticles", commandType: CommandType.StoredProcedure).ToList();
            }

            //articles.FindAll(a=>a.Text.Length>100).ForEach(a=> a.Text = a.Text.Substring(0, 50)+"...");

            return articles;
        }

        public Article Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Article>("GetArticle", new { id },
                                         commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
