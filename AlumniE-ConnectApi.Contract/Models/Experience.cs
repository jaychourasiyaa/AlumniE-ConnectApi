﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlumniE_ConnectApi.Contract;
using AlumniE_ConnectApi.Contract.Enums;

namespace AlumniE_ConnectApi.Contract.Models
{
    public class Experience
    {
        public Guid Id { get; set; }
        public Guid  UserId { get; set; }
        public string JobTittle { get; set; }
        public EmployeementType EmployeementType { set; get; }
        public LocationType LocationType {  set; get; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public bool Ongoing { get; set; } 
        public DateTime ?EndDate { get; set; }
    } 
}
