using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public BlogServices(dbContext _dbContext, IJwtServices jwtServices)
        {
            this.jwtServices = jwtServices;
            this._dbContext = _dbContext;
        }
        public async Task<Guid> AddBlog(AddBlogDto dto)
        {
            try
            {
                var newBlog = new Blog
                {
                    Description = dto.Description,
                    Tags = dto.Tags,
                    ImageUrls = dto.ImageUrls,
                    CreatedBy = jwtServices.Id

                };
                await _dbContext.Blogs.AddAsync(newBlog);
                await _dbContext.SaveChangesAsync();
                return newBlog.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public async Task<List<GetBlogDto>> GetAllBlogs()
        {
            try
            {
                var blogs = new List<GetBlogDto>();
                 blogs = await _dbContext.Blogs.Select(
                    b => new GetBlogDto
                    {
                        Id = b.Id,
                        Description = b.Description,
                        Tags = b.Tags,
                        ImageUrls = b.ImageUrls,
                    }).ToListAsync();
                return blogs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
