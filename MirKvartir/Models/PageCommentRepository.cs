using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MirKvartir.Models
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetComments(int ArticleId);
    }

    public class PageCommentRepository:IPageCommentRepository
    {
        string connectionString = null;
        public PageCommentRepository(string conn)
        {
            connectionString = conn;
        }

        public IEnumerable<PageComment> GetComments(int ArticleId)
        {
            IEnumerable<PageComment> pageComments;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                pageComments = db.Query<PageComment>("GetComments", new{ArticleId}, commandType: CommandType.StoredProcedure);
            }

            return pageComments;
        }
    }
}
