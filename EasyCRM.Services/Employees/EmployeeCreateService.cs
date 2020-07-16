using EasyCRM.Entities.DataConnection;
using EasyCRM.Entities.Login;
using EasyCRM.ViewModels.Employees;
using EasyCRM.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EasyCRM.Services.Employees
{
    public class EmployeeCreateService
    {
        private EasyCRMDBContext db = new EasyCRMDBContext();
        public async Task<int> CreateEmployeeAsync(EmployeeCreateViewModel register)
        {
                EasyCRM.Entities.Employees.Employee user = new EasyCRM.Entities.Employees.Employee();
                user.FirstName = register.FirstName;
                user.LastName = register.LastName;
                user.Email = register.Email;
                user.CreatedDate = DateTime.UtcNow;
                user.Phone = register.Phone;
                user.LastModifiedDate = DateTime.UtcNow;
                user.EmergencyContactPerson = register.EmergencyContactPerson;
                user.EmergencyContactPersonPhone = register.EmergencyContactPersonPhone;
                if (!string.IsNullOrEmpty(register.Password))
                {
                    AspNetUser userObj = new AspNetUser();
                    userObj.FirstName = register.FirstName;
                    userObj.LastName = register.LastName;
                    userObj.Email = register.Email;
                    userObj.Password = register.Password;
                    userObj.CreatedDate = DateTime.UtcNow;
                    userObj.Phone = register.Phone;
                    userObj.LastModifiedDate = DateTime.UtcNow;
                    userObj.ContactPerson = register.EmergencyContactPerson;
                    userObj.CreatedBy = register.CreatedBy;
                    userObj.Modifiedby = register.Modifiedby;
                    db.Employee.Add(user);
                    await db.SaveChangesAsync();
                }
                user.CreatedBy = register.CreatedBy;
                user.Modifiedby = register.Modifiedby;
                db.Employee.Add(user);
                await db.SaveChangesAsync();
                return user.ID;
        }
    }
}