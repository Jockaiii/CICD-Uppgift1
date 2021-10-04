using System.ComponentModel.DataAnnotations;

namespace CICD_Uppgift1.Models
{
    internal class RequestPoll
    {
        [Key]
        public string Username { get; set; }
        public int Salary { get; set; }
        public int OldSalary { get; set; }
        public string Role { get; set; }
        public string OldRole { get; set; }

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