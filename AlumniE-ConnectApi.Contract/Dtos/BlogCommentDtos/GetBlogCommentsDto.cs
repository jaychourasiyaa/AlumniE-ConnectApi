using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogCommentDtos
{
    public class GetBlogCommentsDto
    {
        public string Comment {  get; set; }
        public Guid CommentId { get; set; }
        public string CommentBy {  get; set; }
        public string CommentIdBy { get; set; }
    }
}
