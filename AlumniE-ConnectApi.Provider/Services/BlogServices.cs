using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<GetBlogDto>> GetAllBlogs()
        {
            try
            {
                
                var blogs = await _dbContext.Blogs
                    .Select(
                    b => new GetBlogDto
                    {
                        Id = b.Id,
                        Description = b.Description,
                        ImageUrls = b.ImageUrls,
                        CreatedBy = b.CreatedBy,
                        UpdatedBy = b.UpdatedBy,
                        CreatedOn = b.CreatedOn,
                        UpdatedOn = b.UpdatedOn,
                        CreatedByName = b.CreatedByName,
                        UserProfileHeadLine = b.UserProfileHeadline,
                        UserProfilePictureUrl = b.UserProfilePictureUrl,
                        Tags = b.Tags
                        .Select(t => new IdAndNameDto
                        {
                            Id = t.Tag.Id,
                            Name = t.Tag.Name,
                        }).ToList()
                    }).ToListAsync();
                return blogs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<GetBlogDto> GetBlogById(Guid Id)
        {
            try
            {

                var blogs = await _dbContext.Blogs
                    .Where(b => b.Id == Id)
                    .Select(b => new GetBlogDto
                    {
                        Id = b.Id,
                        Description = b.Description,
                        ImageUrls = b.ImageUrls,
                        CreatedBy = b.CreatedBy,
                        UpdatedBy = b.UpdatedBy,
                        CreatedOn = b.CreatedOn,
                        UpdatedOn = b.UpdatedOn,
                        CreatedByName = b.CreatedByName,
                        UserProfileHeadLine = b.UserProfileHeadline,
                        UserProfilePictureUrl = b.UserProfilePictureUrl,
                        Tags = b.Tags
                        .Select(t => new IdAndNameDto
                        {
                            Id = t.Tag.Id,
                            Name = t.Tag.Name,
                        }).ToList()
                    }).FirstOrDefaultAsync();
                return blogs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Guid> AddBlog(AddBlogDto dto)
        {
            try
            {
                var student = await _dbContext.Students.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();
                var faculty = await _dbContext.Faculties.Where(s => s.Id == jwtServices.Id).FirstOrDefaultAsync();

                var newBlog = new Blog
                {
                    Description = dto.Description,
                    ImageUrls = dto.ImageUrls,
                    CreatedBy = jwtServices.Id,
                    Role = jwtServices.Role,
                    CreatedByName = jwtServices.Name
                };
                if (student != null)
                {
                    newBlog.CreatedByName = student.Name;
                    newBlog.UserProfileHeadline = student.ProfileHeadline;
                    newBlog.UserProfilePictureUrl = student.ProfilePictureUrl;
                }
                else if (faculty != null)
                {
                    newBlog.CreatedByName = faculty.Name;
                    newBlog.UserProfileHeadline = faculty.ProfileHeadline;
                    newBlog.UserProfilePictureUrl = faculty.ProfilePictureUrl;
                }
                await _dbContext.Blogs.AddAsync(newBlog);
                await _dbContext.SaveChangesAsync();
                foreach (var tagId in dto.Tags)
                {
                    var newBlogTag = new BlogTag
                    {
                        BlogId = newBlog.Id,
                        TagId = tagId
                    };
                    await _dbContext.BlogsTags.AddAsync(newBlogTag);
                }
                await _dbContext.SaveChangesAsync();
                return newBlog.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       /* public async Task<int> AddTagsInBlog(AddTagsInBlogDto dto)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == dto.BlogId).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if( jwtServices.Role != "Admin" && jwtServices.Role != "Faculty" && jwtServices.Id != blog.CreatedBy)
                {
                    return -2;
                }
                foreach (var tagId in dto.Tags)
                {
                    var tag = await _dbContext.Tags.Where(t => t.Id == tagId).FirstOrDefaultAsync();
                    if (tag == null)
                    {
                        return -3;
                    }
                    else
                    {
                        var newBlogTag = new BlogTag
                        {
                            BlogId = dto.BlogId,
                            TagId = tagId,
                        };
                        await _dbContext.BlogsTags.AddAsync(newBlogTag);
                    }
                }
                blog.UpdatedBy = jwtServices.Id;
                blog.UpdatedOn = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public async Task<int> UpdateBlogDescription(UpdateBlog dto,Guid blogId)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == blogId).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if( jwtServices.Role != "Admin" && jwtServices.Role != "Faculty" && jwtServices.Id != blog.CreatedBy)
                {
                    return -2;
                }
                blog.Description = dto.Description;
                blog.UpdatedBy = jwtServices.Id;
                blog.UpdatedOn = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*public async Task<int> DeleteTagFromBlog(DeleteTagFromBlogDto dto)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == dto.BlogId).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if( jwtServices.Role != "Admin" && jwtServices.Role != "Faculty" && blog.CreatedBy != jwtServices.Id)
                {
                    return -2;
                }
                var blogTag = await _dbContext.BlogsTags.Where(bt => bt.Blog.Id == dto.BlogId && bt.TagId == dto.TagId).FirstOrDefaultAsync();
                if (blogTag == null)
                {
                    return -3;
                }
                blog.UpdatedBy = jwtServices.Id;
                blog.UpdatedOn = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                _dbContext.BlogsTags.Remove(blogTag);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public async Task<int> DeleteBlog(Guid Id)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == Id).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if (jwtServices.Role != "Admin" && jwtServices.Role != "Faculty" && blog.CreatedBy != jwtServices.Id)
                {
                    return -2;
                }
                _dbContext.Blogs.Remove(blog);
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
