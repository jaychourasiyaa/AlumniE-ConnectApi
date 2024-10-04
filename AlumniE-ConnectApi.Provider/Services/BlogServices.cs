using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
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
                    .Select(b => new GetBlogDto
                    {
                        Id = b.Id,
                        Description = b.Description,
                        ImageUrls = b.ImageUrls,
                        CreatedOn = b.CreatedOn,
                        UpdatedOn = b.UpdatedOn,
                        User = new UserDetailsDto
                        {
                            Id = b.CreatedByStudentId != null ? b.CreatedByStudentId : b.CreatedByFacultyId,
                            Role = b.Role,
                            Name = b.Student != null ? b.Student.Name : b.Faculty.Name,
                            HeadLine = b.Student != null ? b.Student.Headline : b.Faculty.Headline,
                            ImageUrl = b.Student != null ? b.Student.ImageUrl : b.Faculty.ImageUrl
                        },
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
                        CreatedOn = b.CreatedOn,
                        UpdatedOn = b.UpdatedOn,
                        User = new UserDetailsDto
                        {
                            Id = b.CreatedByStudentId != null ? b.CreatedByStudentId : b.CreatedByFacultyId,
                            Role = b.Role,
                            Name = b.Student != null ? b.Student.Name : b.Faculty.Name,
                            HeadLine = b.Student != null ? b.Student.Headline : b.Faculty.Headline,
                            ImageUrl = b.Student != null ? b.Student.ImageUrl : b.Faculty.ImageUrl
                        },
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
                    Role = jwtServices.Role,
                    CreatedByStudentId = jwtServices.Role == UserRole.Student ? jwtServices.Id : null,
                    CreatedByFacultyId = jwtServices.Role == UserRole.Faculty ? jwtServices.Id : null,
                };
               
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
        public async Task<int> AddTagsInBlog(AddTagsInBlogDto dto)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == dto.BlogId).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if (jwtServices.Role != UserRole.Admin && jwtServices.Role != UserRole.Faculty && jwtServices.Id != blog.CreatedByFacultyId && jwtServices.Id != blog.CreatedByStudentId)
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
                blog.UpdatedOn = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> UpdateBlogDescription(UpdateBlog dto, Guid blogId)
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
                blog.Description = dto.Description;
                blog.UpdatedOn = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "India Standard Time");
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> DeleteTagFromBlog(DeleteTagFromBlogDto dto)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == dto.BlogId).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if (jwtServices.Role != UserRole.Admin && jwtServices.Role != UserRole.Faculty && jwtServices.Id != blog.CreatedByFacultyId && jwtServices.Id != blog.CreatedByStudentId)
                {
                    return -2;
                }
                var blogTag = await _dbContext.BlogsTags.Where(bt => bt.Blog.Id == dto.BlogId && bt.TagId == dto.TagId).FirstOrDefaultAsync();
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
        public async Task<int> DeleteBlog(Guid Id)
        {
            try
            {
                var blog = await _dbContext.Blogs.Where(b => b.Id == Id).FirstOrDefaultAsync();
                if (blog == null)
                {
                    return -1;
                }
                if (jwtServices.Role != UserRole.Admin && jwtServices.Role != UserRole.Faculty && jwtServices.Id != blog.CreatedByFacultyId && jwtServices.Id != blog.CreatedByStudentId)
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
