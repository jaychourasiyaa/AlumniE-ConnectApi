﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BranchDtos
{
    public class GetBranchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
