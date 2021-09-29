using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CICD_Uppgift1.Models
{
    public abstract class Account
    {
        [Key]
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual int Balance { get; set; }
        public virtual int Salary { get; set; }
        public virtual string Role { get; set; }

        public virtual void GetAccountDetails(string userName)
        {
            List<Account> logList = new List<Account>();

            using var db = new Database.Database();
            var accountQuery = from l in db.AdminAccount.Include("Balance").Include("Salary").Include("Role")
                               where l.Username = l.UserName
                               select l;

            accountQuery.Balance = Balance;
            accountQuery.Salary = Salary;
            accountQuery.Role = Role;
        }
    }
}
