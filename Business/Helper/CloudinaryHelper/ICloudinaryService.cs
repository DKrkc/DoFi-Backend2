
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.CloudinaryHelper
{
   public  interface ICloudinaryService
    {
        
      //  ImageForReturnDto upload(int userId,ImageForCreationDto imageForCreationDto);
       Image upload(int userId, ImageForCreationDto imageForCreationDto);


    }
}
