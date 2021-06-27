using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Domain
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
