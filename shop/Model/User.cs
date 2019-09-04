using System;
namespace shop.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User GetSampleUser()
        {
            return new User() { Id = 1, UserName = "John", Email = "example@gmail.com", Password = "abc" };
        }
    }
}
