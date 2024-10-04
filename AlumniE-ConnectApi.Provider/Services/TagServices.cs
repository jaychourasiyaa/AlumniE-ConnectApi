using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class TagServices : ITagServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        public TagServices(dbContext _dbContext, IJwtServices jwtServices)
        {
            this._dbContext = _dbContext;
            this.jwtServices = jwtServices;
        }
        public async Task<int> AddTags(List<string> tags, Guid blogId)
        {
            try
            {
                if (jwtServices.Role == UserRole.Student)
                {
                    var student = await _dbContext.Students.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();
                    if (student == null)
                    {
                        return -1;
                    }
                }
                else if (jwtServices.Role == UserRole.Faculty)
                {
                    var faculty = await _dbContext.Faculties.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();
                    if (faculty == null)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -3;
                }
                var tagsId = new List<Guid>();
                foreach (var name in tags)
                {
                    var tagName = name.Trim();
                    tagName = Regex.Replace(tagName, @"\s+", " ").Trim();
                    var tag = await _dbContext.Tags.Where(s => s.Name.ToUpper() == tagName.ToUpper()).FirstOrDefaultAsync();
                    if (tag != null)
                    {
                        return -2;
                    }
                    var newTag = new Tag
                    {
                        Name = tagName,
                    };
                    await _dbContext.Tags.AddAsync(newTag);
                    tagsId.Add(newTag.Id);
                }
                await _dbContext.SaveChangesAsync();
                await AddTagsToBlog(tagsId, blogId);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> AddTagsToBlog(List<Guid> tags, Guid blogId)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == blogId).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                foreach (var tagId in tags)
                {
                    var tag = await _dbContext.Tags.Where(t => t.Id == tagId).FirstOrDefaultAsync();
                    if (tag == null)
                    {
                        return -2;
                    }
                    else
                    {
                        var tagAlreadyExists = await _dbContext.BlogsTags.Where(t => t.TagId == tagId && t.BlogId == blogId).FirstOrDefaultAsync();
                        if (tagAlreadyExists != null)
                        {
                            return -3;
                        }
                    }
                }
                foreach (var tagId in tags)
                {
                    var newBlogTag = new BlogTag
                    {
                        BlogId = blogId,
                        TagId = tagId,
                    };
                    await _dbContext.BlogsTags.AddAsync(newBlogTag);
                }
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> DeleteTagFromBlog(Guid blogId, Guid tagId)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == blogId).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if (jwtServices.Role != UserRole.Admin && jwtServices.Role != UserRole.Faculty && jwtServices.Id != blog.CreatedByFacultyId && jwtServices.Id != blog.CreatedByStudentId)
                {
                    return -2;
                }
                var blogTag = await _dbContext.BlogsTags.Where(bt => bt.Blog.Id == blogId && bt.TagId == tagId).FirstOrDefaultAsync();
                if (blogTag == null)
                {
                    return -3;
                }
               
                blog.UpdatedOn = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                _dbContext.BlogsTags.Remove(blogTag);
                await _dbContext.SaveChangesAsync();
                return 1;
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
        public async Task<List<IdAndNameDto>> GetAllTagsStartsWith(string startsWith)
        {
            try
            {
                var tags = await _dbContext.Tags
                    .Where(s => s.Name.ToLower()
                .StartsWith(startsWith.ToLower()))
                .Select(s => new IdAndNameDto
                {
                    Id = s.Id,
                    Name = s.Name
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
