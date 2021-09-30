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

        public abstract bool GetAccountDetails(string userName);
    }
}
