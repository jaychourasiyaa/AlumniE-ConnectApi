using AlumniE_ConnectApi.Contract.Dtos.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IBlogServices
    {
        public Task<GetBlogDto> GetBlogById(Guid Id);
        public Task<List<GetBlogDto>> GetAllBlogs();
        public Task<Guid> AddBlog(AddBlogDto dto);
        public Task<int> UpdateBlogDescription(UpdateBlog dto,Guid blogId);
        public Task<int> DeleteBlog(Guid Id);
    }
}
