using CorService.Services.IService;
using CorService.ViewModels.Users;
using DataLayer.Context;
using DataLayer.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorService.Services.UserService
{
   public class UserService:IUserService
    {
        DigikalaContext _context;
        public UserService(DigikalaContext context)
        {
            _context = context;
        }

        public List<ShowUserViewModel> ShowUsers()
        {
           return _context.Users.Select(u=>new ShowUserViewModel
           {
               UserId=u.UserId,
               FullName=u.FullName,
               Phone=u.Phone,
               IActive=u.IsActive
           }).ToList();
        }
        public int AddUser(DataLayer.Entites.User.User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user.UserId;
            }
            catch
            {
                return 0;
            }


        }
        public User FindUserById(int id)
        {
            return _context.Users.Find(id);
        }
        public bool EditUser(User user)
        {
            try
            {
                _context.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ActiveEmailViewModel GetUserForForgetPassword(string phone)
        {
            return _context.Users.Where(u => u.Phone == phone).Select(a => new ActiveEmailViewModel
            {
                UserId = a.UserId,
                ActiveCode = a.PhoneActiveCode.ToString(),
            }).SingleOrDefault();
        }
        public bool IsExcitePhoneNumber(RegisterUserViewModel model)
        {
          bool use=  _context.Users.Any(u => u.Phone == model.Phone);
            if(use==true)
            return false;
            return true;
        }
        public User UserLogin(string phone)
        {
            return _context.Users.Where(u => u.Phone == phone).SingleOrDefault();
        }
    }
}
