using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {


        IAdService _adService;
        ICityService _cityService;
        IRegionService _regionService;

        public AdvertisementsController(IAdService adService, ICityService cityService, IRegionService regionService)
        {
            _adService = adService;
            _cityService=cityService; 
            _regionService=regionService;

        }



        [HttpPost("add")]
        public IActionResult Add(Ad ad)
        {
            var result =_adService.Add(ad);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Ad ad)
        {
            var result = _adService.UpDate(ad);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int adId)
        {
            var ad = _adService.FindByAdId(adId).Data;
            if (ad == null)
            {
                return BadRequest("Ilan zaten silindi");
            }
            var result = _adService.Delete(ad);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getAllAds")]
        public IActionResult GetAllAds()
        {
            var result = _adService.getAllAds();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getAdById")]
        public IActionResult GetAdById(int adId)
        {
            var result = _adService.FindByAdId(adId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getallAdDetails")]
        public IActionResult GetAllAdDetails()
        {
            var result = _adService.GetAllAdDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("getallAdDetailsByCity")]
        public IActionResult GetAllAdDetailsByCityId(int cityId)

        {

            var city=_cityService.GetByCityId(cityId).Data;

            var result = _adService.GetAllAdDetailsByCityName(city.cityName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpGet("getallAdDetailsbyCityAndByRegion")]
        public IActionResult GetAllAdDetailsByCityId(int cityId,int regionId)

        {

            var city = _cityService.GetByCityId(cityId).Data;
            var region = _regionService.FindById(regionId).Data;

            var result = _adService.getAllAdDetailsByCityAndByRegion(city.cityName, region.regionName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("getallAdDetailsByUserId")]
        public IActionResult GetAllAdDetailsByUserId(int userId)

        {
            var result = _adService.GetAllAdDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getallAdDetailsByAdId")]
        public IActionResult GetAllAdDetailsByAdId(int adId)

        {
            var result = _adService.GetAllAdDetailsByAdId(adId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
