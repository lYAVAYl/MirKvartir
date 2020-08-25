using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace MirKvartir.Models
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(int id);
        User Get(string log);
        List<User> GetUsers();
        void Update(User user);
    }

    public class UserRepository : IUserRepository
    {
        string connectionString = null;
        public UserRepository(string conn)
        {
            connectionString = conn;
        }

        public List<User> GetUsers()
        {
            List<User> users;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                users = db.Query<User>("GetUsers", commandType: CommandType.StoredProcedure).ToList();
            }

            return users;
        }

        public User Get(string log)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("GetUser", new { log }, commandType:CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name) VALUES(@Name)";
                db.Execute(sqlQuery, user);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name WHERE UserId = @UserId";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE UserId = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }

}
