using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Enums
{
    public enum EmployeementType :byte
    {
        FullTime = 0,
        PartTime = 1,
        SelfEmployed = 2,
        Freelance = 3,
        Internship = 4,
        Trainee = 5
    }
}
