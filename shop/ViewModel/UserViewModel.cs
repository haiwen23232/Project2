using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using shop.Data;
using shop.Model;

namespace shop.ViewModel
{
    public class UserViewModel: INotifyPropertyChanged
    {
        UsersManager usersManager = new UsersManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _result;
        private User _user;

        public bool Result
        {
            get { return _result; }
            set
            {
                _result = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("User"));
            }
        }

        public bool FetchByEmailAsync(string email)
        {
            return usersManager.FetchUserByEmailAsync(email);

        }

        public void FetchByNameAsync(string name)
        {
            User = usersManager.FetchUserByNameAsync(name);
        }

        public void FetchByIdAsync(int id)
        {
            User = usersManager.FetcyUserByIdAsync(id);
        }

        public async Task CreateUser(User user)
        {
            await usersManager.CreateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            await usersManager.UpdateUser(user);
        }

        public UserViewModel()
        {
        }

    }
}
