using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Enums
{
    public enum JobType : byte
    {
        FullTime = 0,
        PartTime = 1,
        Contract = 3,
        Temporary = 4,
        Other = 5,
        Volunteer = 6,
    }
}
