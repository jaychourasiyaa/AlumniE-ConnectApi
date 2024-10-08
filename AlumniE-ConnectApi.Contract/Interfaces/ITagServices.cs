using AlumniE_ConnectApi.Contract.Dtos;
using AlumniE_ConnectApi.Contract.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface ITagServices
    {
        public Task<List<IdAndNameDto>> GetAllTags();
        public Task<List<IdAndNameDto>> GetAllTagsStartsWith(string startsWith);
        public Task<string> AddTag(string tagName);
     /*   public Task<int> AddTagsToBlog(List<Guid> tags,Guid blogId);
        public Task<int> DeleteTagFromBlog(Guid blogId, Guid TagId);*/

    }
}
