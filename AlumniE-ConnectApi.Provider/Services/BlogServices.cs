using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public BlogServices( dbContext _dbContext, IJwtServices jwtServices)
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
                    ImageUrls = dto.ImageUrls

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
        private List<string> ExtractLinks(string Description)
{
    var links = new List<string>();
    return links;
}
    }
    
}
