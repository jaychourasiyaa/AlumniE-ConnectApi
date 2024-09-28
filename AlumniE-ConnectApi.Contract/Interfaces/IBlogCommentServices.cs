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
        public Task <Guid> AddComments(AddBlogCommmentDto dto);
    }
}
