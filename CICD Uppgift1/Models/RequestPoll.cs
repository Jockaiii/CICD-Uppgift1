namespace CICD_Uppgift1.Models
{
    internal class RequestPoll
    {
        public string Username { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }

        public RequestPoll(string username, int salary)
        {
            Username = username;
            Salary = salary;
        }

        public RequestPoll(string username, string role)
        {
            Username = username;
            Role = role;
        }
    }
}