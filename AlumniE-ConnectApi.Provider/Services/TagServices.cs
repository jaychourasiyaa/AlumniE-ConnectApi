using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class TagServices : ITagServices
    {
        private readonly dbContext _dbContext;
        public TagServices(dbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<Guid> AddTag(string name)
        {
            try
            {
                var newTag = new Tag
                {
                    Name = name,
                };
                await _dbContext.Tags.AddAsync(newTag);
                await _dbContext.SaveChangesAsync();
                return newTag.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<IdAndNameDto>> GetAllTags()
        {
            try
            {
                var tags = new List<IdAndNameDto>();
                tags = await _dbContext.Tags.Select(
                t => new IdAndNameDto
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();
                return tags;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
