﻿using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Responses;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class UniversityServices : IUniversityServices
    {
        private readonly dbContext _dbContext;
        public UniversityServices(dbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Guid> AddUniversity(string name)
        {
            try
            {
                var newUniversity = new University
                {
                    Name = name,
                };
                await _dbContext.Universities.AddAsync(newUniversity);
                await _dbContext.SaveChangesAsync();
                return newUniversity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
