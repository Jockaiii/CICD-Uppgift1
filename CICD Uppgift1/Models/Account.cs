using System.ComponentModel.DataAnnotations;

namespace CICD_Uppgift1.Models
{
    internal abstract class Account
    {
        [Key]
        public string UserName { get; set; }
        protected internal virtual string Password { get; set; }
        protected internal virtual int Balance { get; set; }
        protected internal virtual int Salary { get; set; }
        protected internal virtual string Role { get; set; }

        protected internal abstract bool GetAccountDetails(string userName);
    }
}
