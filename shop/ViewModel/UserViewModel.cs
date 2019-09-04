using System;
using shop.Model;

namespace shop.ViewModel
{
    public class UserViewModel
    {
        public User John { get; set; }
        public UserViewModel()
        {
            John = new User().GetSampleUser();
        }
    }
}
