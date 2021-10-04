using System.ComponentModel.DataAnnotations;

namespace CICD_Uppgift1.Models
{
    internal class RequestPoll
    {
        [Key]
        public string Username { get; set; } // Username of the account of which the requestpoll is created from.
        public int Salary { get; set; } // the salary the user is requesting.
        public int OldSalary { get; set; } // the current salary of the account.
        public string Role { get; set; } // the role the user is requesting.
        public string OldRole { get; set; } // the current role of the account.

        /// <summary>
        /// Constructor for creating a requestpoll to be added to the database.
        /// </summary>
        /// <param name="username">Username of the account of which the requestpoll is created from.</param>
        /// <param name="salary">the salary the user is requesting</param>
        /// <param name="oldSalary">the current salary of the account</param>
        /// <param name="role">the role the user is requesting.</param>
        /// <param name="oldRole">the current role of the account.</param>
        /// <param name="oldRole">the current role of the account.</param>
        public RequestPoll(string username, int salary, int oldSalary, string role, string oldRole)
        {
            Username = username;
            Salary = salary;
            OldSalary = oldSalary;
            Role = role;
            OldRole = oldRole;
        }
    }
}