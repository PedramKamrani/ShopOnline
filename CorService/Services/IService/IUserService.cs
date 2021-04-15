using CorService.ViewModels.Users;
using DataLayer.Entites.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorService.Services.IService
{
   public interface IUserService
    {
        List<ShowUserViewModel> ShowUsers();
        int AddUser(DataLayer.Entites.User.User user);
        User FindUserById(int id);
        bool EditUser(User user);
        ActiveEmailViewModel GetUserForForgetPassword(string email);
        bool IsExcitePhoneNumber(RegisterUserViewModel model);
        User UserLogin(string phone);
    }
}
