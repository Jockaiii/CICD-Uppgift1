namespace CICD_Uppgift1.Models
{
    internal class RequestPoll
    {
        public string Username { get; set; }
        public int Salary { get; set; }
        public int OldSalary { get; set; }
        public string Role { get; set; }
        public string OldRole { get; set; }

        public RequestPoll(string username, int salary, int oldSalary)
        {
            Username = username;
            Salary = salary;
            OldSalary = oldSalary;
        }

        public RequestPoll(string username, string role, string oldRole)
        {
            Username = username;
            Role = role;
            OldRole = oldRole;
        }
    }
}