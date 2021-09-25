using System;
using System.Collections.Generic;
using System.Text;

namespace CICD_Uppgift1.Controller
{
    public abstract class Account
    {
        public virtual int Balance { get; set; }
        public virtual int Salary { get; set; }
        public virtual string Role { get; set; }

        public virtual void CheckAccountBalance()
        {

        }

        public virtual void CheckSalary()
        {

        }

        public virtual void CheckRole()
        {

        }
    }
}
