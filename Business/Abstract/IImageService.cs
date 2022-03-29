

using Core6.Results;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {

        bool add(Image image);
        IDataResult<ImageForReturnDto> upload(ImageForCreationDto imageForCreationDto, int userId);
    }
}
