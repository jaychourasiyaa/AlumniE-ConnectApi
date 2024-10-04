using AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos;
using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public async Task<List<GetBlogCommentsDto>> GetBlogComment(Guid blogId)
        {
            try
            {
                var blogComments = new List<GetBlogCommentsDto>();
                blogComments = await _dbContext.BlogsComments.Where(b => b.BlogId == blogId)
                    .Select(b => new GetBlogCommentsDto
                    {
                        CommentId = b.Id,
                        Comment = b.Comment,
                        User = new UserInfo
                        {
                            Id = b.CreatedByStudentId != null ? b.CreatedByStudentId : b.CreatedByFacultyId,
                            Role = b.Role,
                            Name = b.Student != null ? b.Student.Name : b.Faculty.Name,
                            ImageUrl = b.Student != null ? b.Student.ImageUrl : b.Faculty.ImageUrl
                        },

                    }).ToListAsync();
                return blogComments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> AddComment(AddBlogCommmentDto dto ,Guid blogId)
        {
            try
            {
                var newBlogComment = new BlogComment
                {
                    BlogId = blogId,
                    Comment = dto.Comment,
                    Role = jwtServices.Role,
                    CreatedByStudentId = jwtServices.Role == UserRole.Student ? jwtServices.Id : null,
                    CreatedByFacultyId = jwtServices.Role == UserRole.Faculty ? jwtServices.Id : null,
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
        public async Task<int> UpdateComment(UpdateBlogCommentDto dto ,Guid commentId)
        {
            try
            {
                var blogComment = await _dbContext.BlogsComments.Where(b => b.Id == commentId)
                    .FirstOrDefaultAsync();
                if (blogComment == null)
                {
                    return -1;
                }
                else if (jwtServices.Role != UserRole.Admin && jwtServices.Role != UserRole.Faculty && jwtServices.Id != blogComment.CreatedByFacultyId && jwtServices.Id != blogComment.CreatedByStudentId)
                {
                    return -2;
                }
                else if (blogComment.Comment == dto.Comment)
                {
                    return -3;
                }
                blogComment.Comment = dto.Comment;
                
                blogComment.UpdatedOn = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Delete(Guid id)
        {
            try
            {
                var blogComment = await _dbContext.BlogsComments.Where(b => b.Id == id)
                    .FirstOrDefaultAsync();
                if (blogComment == null)
                {
                    return -1;
                }
                else if (jwtServices.Role != UserRole.Admin && jwtServices.Role != UserRole.Faculty && jwtServices.Id != blogComment.CreatedByFacultyId && jwtServices.Id != blogComment.CreatedByStudentId)
                {
                    return -2;
                }
                _dbContext.BlogsComments.Remove(blogComment);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




    }
}
