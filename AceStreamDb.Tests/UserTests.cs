using AceStream.Core.Entity.Models;
using NUnit.Framework;

namespace AceStreamDb.Tests
{
    public class UserTests
    {
        [Test]
        public void SaveUserTest()
        {
            var sql = new DataBase();

            var user = new User()
            {
                Email = "test@mail.ru",
                Name = "Test",
                Password = "pass"
            };

            sql.SaveUser(user.Name, user.Email, user.Password);
        }

        [Test]
        public void GetUserTest()
        {
            var sql = new DataBase();

            var email = "test@mail.ru";

            var pass = "pass";

            var user = sql.GetUser(email, pass);
        }
    }
}
