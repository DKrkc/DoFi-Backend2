
using Core6.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ImageForCreationDto:IDto
    {

      //  public int imageId { get; set; }
        public IFormFile file { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public string publicId { get; set; }

        public ImageForCreationDto()
        {
            date=DateTime.Now;
        }
    }
}

