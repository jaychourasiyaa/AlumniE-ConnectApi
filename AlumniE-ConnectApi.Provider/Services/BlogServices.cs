using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using AlumniE_ConnectApi.Contract.Dtos.UserDtos;
using AlumniE_ConnectApi.Contract.Enums;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Provider.Database;
using AlumniE_ConnectApi.Provider.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AlumniE_ConnectApi.Provider.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly dbContext _dbContext;
        private readonly IJwtServices jwtServices;
        private readonly CloudinaryServices mediaServices;
        public BlogServices(dbContext _dbContext, IJwtServices jwtServices, CloudinaryServices imageServices)
        {
            this.jwtServices = jwtServices;
            this._dbContext = _dbContext;
            this.mediaServices = imageServices;
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
                        MediaUrls = b.MediaUrls,
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
                        MediaUrls = b.MediaUrls,
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
        public async Task<string> AddBlog(AddBlogDto dto)
        {
            try
            {
                
                dto.Description = dto.Description != null ? dto.Description.Trim() : dto.Description;
                if(string.IsNullOrEmpty(dto.Description) == true && (dto.Tags == null || dto.Tags.Count == 0) && (dto.MediaFiles == null || dto.MediaFiles.Count ==0))
                {
                    return "-1";
                }
                bool tagsValidity = (dto.Tags != null && dto.Tags.Count() != 0) ? await CheckTags(dto.Tags) : true;
                if (!tagsValidity)
                {
                    return "-2";
                }
                var imageUrls = new List<string>();
                foreach( var image in dto.MediaFiles)
                {
                    var url = await mediaServices.UploadMediaAsync(image);
                    if(url != null)
                    {
                        imageUrls.Add(url);
                    }
                }
                var newBlog = new Blog
                {
                    Description = dto.Description,
                    MediaUrls = imageUrls,
                    Role = jwtServices.Role,
                    CreatedByStudentId = jwtServices.Role == UserRole.Student ? jwtServices.Id : null,
                    CreatedByFacultyId = jwtServices.Role == UserRole.Faculty ? jwtServices.Id : null,
                };
                await _dbContext.Blogs.AddAsync(newBlog);
                await _dbContext.SaveChangesAsync();
                if (dto.Tags != null && dto.Tags.Count() != 0)
                {
                    await AddTagsInBlog(dto.Tags, newBlog.Id);
                }
                await _dbContext.SaveChangesAsync();
                return newBlog.Id.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateBlog(UpdateBlogDto dto, Guid blogId)
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
                bool updated = false;
                dto.Description = dto.Description != null ? dto.Description.Trim() : dto.Description;
                if (string.IsNullOrEmpty(dto.Description) == false && blog.Description != dto.Description)
                {
                    blog.Description = dto.Description;
                    updated = true;
                }
                if (dto.RemoveTags != null && dto.RemoveTags.Count != 0)
                {
                    bool tagsValidity = await CheckTags(dto.RemoveTags);
                    if (!tagsValidity)
                    {
                        return -3;
                    }
                    updated = await DeleteTagFromBlog(dto.RemoveTags, blogId);
                }
                if (dto.AddTags != null && dto.AddTags.Count != 0)
                {
                    bool tagsValidity = await CheckTags(dto.AddTags) ;
                    if (!tagsValidity)
                    {
                        return -4 ;
                    }
                    updated = await AddTagsInBlog(dto.AddTags, blogId);
                }
                if(!updated)
                {
                    return -5;
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


        //#helper
        private async Task<bool> CheckTags(List<Guid> tags)
        {
            try
            {
                var validity = true;
                foreach (var tagId in tags)
                {
                    var tag = await _dbContext.Tags.Where(t => t.Id == tagId).FirstOrDefaultAsync();
                    if (tag == null)
                    {
                        validity = false;
                        break;
                    }
                }
                return validity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<bool> AddTagsInBlog(List<Guid> tags, Guid blogId)
        {
            try
            {
               
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
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteTagFromBlog(List<Guid> tags, Guid blogId)
        {
            try
            {
                bool updated = false;
                foreach (var tagId in tags)
                {
                    var blogTag = await _dbContext.BlogsTags.Where(bt => bt.Blog.Id == blogId && bt.TagId == tagId).FirstOrDefaultAsync();
                    if (blogTag != null)
                    {
                        _dbContext.BlogsTags.Remove(blogTag);
                        await _dbContext.SaveChangesAsync();
                        updated = true;
                    }
                }
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
