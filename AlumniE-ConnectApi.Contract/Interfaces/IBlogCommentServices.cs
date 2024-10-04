using AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IBlogCommentServices
    {
        public Task<List<GetBlogCommentsDto>> GetBlogComment(Guid blogId);

        public Task <Guid> AddComment(AddBlogCommmentDto dto,Guid blogId);
        public Task <int> UpdateComment(UpdateBlogCommentDto dto,Guid commentId);
        public Task <int> Delete(Guid id);
    }
}
