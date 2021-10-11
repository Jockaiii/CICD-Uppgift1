using System.ComponentModel.DataAnnotations;

namespace CICD_Uppgift1.Models
{
    public abstract class Account
    {
        [Key]
        public string UserName { get; set; } // Username string for the account
        public virtual string Password { get; set; } // Password string for the account
        public virtual int Balance { get; set; } // Balance int for the account
        public virtual int Salary { get; set; } // Salary int for the account
        public virtual string Role { get; set; } // Role string for the account

        /// <summary>
        /// abstract method for inherent classes to override in order for them to gather AccountData after sucessful login.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>True or false dependent on if account data was found or not.</returns>
        public abstract bool GetAccountDetails(string userName);
    }
}
