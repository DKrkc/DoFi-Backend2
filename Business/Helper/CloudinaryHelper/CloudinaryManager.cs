using AutoMapper;
using Business.Abstract;
using Business.Helper.CloudinaryHelper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core6.Utilities.Helpers;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.CloudinaryHelper
{
    public class CloudinaryManager : ICloudinaryService
    {
        public IConfiguration Configuration { get; }
        //IOptions<CloudinarySettings> _cloudinaryConfig;
        private CloudinarySettings _cloudinarySettings;
        IMapper _mapper;
        Cloudinary _cloudinary;
       

        public CloudinaryManager(IConfiguration configuration,IMapper mapper)
        {
            Configuration = configuration;  
             _cloudinarySettings= Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            _mapper= mapper;


            Account account = new Account(_cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey,
                _cloudinarySettings.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        //public CloudinaryManager(IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper)
        //{
        //    _cloudinaryConfig = cloudinaryConfig;

        //    _mapper = mapper;






        //    Account account = new Account(
        //        _cloudinaryConfig.Value.CloudName,
        //        _cloudinaryConfig.Value.ApiKey,
        //        _cloudinaryConfig.Value.ApiSecret);
        //    _cloudinary = new Cloudinary(account);

        //}




        public Image upload(int userId,ImageForCreationDto imageForCreationDto)
        {

          

            var file = imageForCreationDto.file;
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
              using (var stream = file.OpenReadStream())
              {
                  var uploadParams = new ImageUploadParams
                  {
                       File = new FileDescription(file.Name, stream)
                   };

                   uploadResult = _cloudinary.Upload(uploadParams);
               }
            }

            imageForCreationDto.url = uploadResult.Url.ToString();
            imageForCreationDto.publicId = uploadResult.PublicId;

            var image = _mapper.Map<Image>(imageForCreationDto);
            image.userId=userId;
            image.isMain = true;

            return image;
            

            //var image = new Image { 
            //    userId = userId,
            //    url=imageForCreationDto.url,
            //    date=imageForCreationDto.date,
            //    publicId=imageForCreationDto.publicId,
            //    description=""

            //};



            //return new ImageForReturnDto
            //{
            //   imageId = image.imageId,
            //  url = image.url,
            //   description = "",
            //    date = image.date,
            //    isMain = true,
            //   publicId = image.publicId,



            //};

        }
    }
}
