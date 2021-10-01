using System.ComponentModel.DataAnnotations;

namespace CICD_Uppgift1.Models
{
    internal abstract class Account
    {
        [Key]
        public string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual int Balance { get; set; }
        public virtual int Salary { get; set; }
        public virtual string Role { get; set; }

        protected internal abstract bool GetAccountDetails(string userName);
    }
}
