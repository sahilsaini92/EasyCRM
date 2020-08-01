using EasyCRM.Entities.DataConnection;
using EasyCRM.Entities.Login;
using EasyCRM.Models;
using EasyCRM.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EasyCRM.Services.Account
{
    public class UserCreateService
    {
        private EasyCRMDBContext db = new EasyCRMDBContext();

        public async Task<int> CreateUserAsync(AspNetUserViewModel register)
        {
            AspNetUser user = new AspNetUser();
            user.FirstName = register.FirstName;
            user.LastName = register.LastName;
            user.Email = register.Email;
            user.CreatedDate = DateTime.UtcNow;
            user.Phone = register.Phone;
            user.LastModifiedDate = DateTime.UtcNow;
            user.ContactPerson = register.ContactPerson;
            user.City = register.City;
            user.Password = register.Password;
            user.CreatedBy = register.CreatedBy;
            user.Modifiedby = register.Modifiedby;
            db.AspNetUser.Add(user);
            await db.SaveChangesAsync();
            return user.ID;
        }

        public async Task<bool> LoginCheck(LoginViewModel vm)
        {
            var isUser = db.AspNetUser.Where(u => u.Email == vm.Email && u.Password == vm.Password).Any();
            return isUser;
        }
    }
}