using AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class BlogCommentServices : IBlogCommentServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public BlogCommentServices(dbContext _dbContext, IJwtServices jwtServices)
        {
            this._dbContext = _dbContext;
            this.jwtServices = jwtServices;
        }
        public async Task <Guid> AddComments(AddBlogCommmentDto dto)
        {
            try
            {
                var newBlogComment = new BlogComment
                {
                    BlogId = dto.BlogId,
                    Comment = dto.Comment,
                    CreatedBy = jwtServices.Id
                };
                await _dbContext.BlogsComments.AddAsync(newBlogComment);
                await _dbContext.SaveChangesAsync();
                return newBlogComment.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
