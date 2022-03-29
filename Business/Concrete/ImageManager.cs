using AutoMapper;
using Business.Abstract;
using Business.Helper.CloudinaryHelper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

using Core6.Results;
using Core6.Utilities.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {

        public IConfiguration Configuration { get; }
        private CloudinarySettings _cloudinarySettings;
        IMapper _mapper;
        Cloudinary _cloudinary;
        IUserService _userService;
        IImageDal _imageDal;


        public ImageManager(IConfiguration configuration, IMapper mapper, IUserService userService, IImageDal imageDal)
        {
            Configuration = configuration;
            _cloudinarySettings = Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            _mapper = mapper;
            _userService = userService;
            _imageDal = imageDal;


            Account account = new Account(_cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey,
                _cloudinarySettings.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }











        //IImageDal _imageDal;

        //IUserService _userService;
        //IOptions<CloudinarySettings> _cloudinaryConfig;
        //IMapper _mapper;
        //Cloudinary _cloudinary;
        //DogWalkerContext _contex;
        //public ImageManager(IImageDal imageDal, ICloudinaryService cloudinaryService, IUserService userService, IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper, DogWalkerContext contex)
        //{
        //    _imageDal = imageDal;

        //    _userService = userService;
        //    _cloudinaryConfig = cloudinaryConfig;

        //    _mapper = mapper;
        //    _contex= contex;


        //    Account account = new Account(
        //        _cloudinaryConfig.Value.CloudName,
        //        _cloudinaryConfig.Value.ApiKey,
        //        _cloudinaryConfig.Value.ApiSecret);
        //    _cloudinary = new Cloudinary(account);
        //}


        public bool add(Image image)
        {
            if (image == null)
            {
                return false;
            }
            _imageDal.Add(image);
            return true;

        }





        public IDataResult<ImageForReturnDto> upload(ImageForCreationDto imageForCreationDto, int userId)
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
            image.userId = userId;

            if (image.isMain == null)
            {
                image.isMain = true;
            }


            //var image = new Image
            //{
            //    userId = userId,
            //    url = imageForCreationDto.url,
            //    date = imageForCreationDto.date,
            //    publicId = imageForCreationDto.publicId,
            //    description = ""

            //};

            //  _contex.Images.Add(image);

            // _imageDal.Add(image);


            if (add(image))
            {
                var imageForReturn = _mapper.Map<ImageForReturnDto>(image);
                return new SuccessDataResult<ImageForReturnDto>(imageForReturn, "Resim geldi");
            }

            return new ErrorDataResult<ImageForReturnDto>("Resim yuklenemedi");
            //return new ImageForReturnDto
            //{
            //   imageId = image.imageId,
            //   url = image.url,
            //   description = image.description,
            //   date = image.date,
            //   isMain = true,
            //   publicId = image.publicId,



            //};






        }
    }
}
