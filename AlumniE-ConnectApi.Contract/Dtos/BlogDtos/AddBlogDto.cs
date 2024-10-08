﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Dtos.BlogDtos
{
    public class AddBlogDto
    {
        [MaxLength(1000)]
        [MinLength(1)]
        [RegularExpression(@"^(?!\s+$).+", ErrorMessage = "Description should not consist only of spaces.")]
        public string? Description { get; set; }
        public List<Guid>? Tags { get; set; }
        public List<IFormFile>? MediaFiles { get; set; }
    }
}
