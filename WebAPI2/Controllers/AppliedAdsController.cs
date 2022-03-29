using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppliedAdsController : ControllerBase
    {


        IAppliedAdService _appliedadService;
        IAdService _adService;
        public AppliedAdsController(IAppliedAdService appliedadService, IAdService adService)
        {
            _appliedadService = appliedadService;
            _adService= adService;
        }


        [HttpPost("addAppliedAdInfo")]
        public IActionResult Add(AppliedAd appliedAd)
        {
            var isThereanyAds = _adService.GetAllAdDetailsByUserId(appliedAd.jobSeekerId).Data;
            foreach (var item in isThereanyAds)
            {
                if (appliedAd.adId == item.adId)
                {
                    return BadRequest("Bu ilan zaten sizin");
                }
            }
            var appliedJobs = _appliedadService.GetAppliedAdDetailsByUserId(appliedAd.jobSeekerId).Data;

            if (appliedJobs!=null)
            {
                foreach (var item in appliedJobs)
                {
                    if (item.adId == appliedAd.adId)
                    {
                        return BadRequest("Bu ilana zaten basvuruldu.");
                    }
                }
            }


            var result = _appliedadService.Add(appliedAd);

            return Ok(result);

        }


        [HttpDelete("delete")]
        public IActionResult Delete(int adId, int jobSeekerId)
        {

            var listAppliedJobs = _appliedadService.FindTheListOfAppliedJobsByAdId(adId).Data;
            foreach (var item in listAppliedJobs)
            {
                if (item.jobSeekerId == jobSeekerId)
                {
                    var deleteJob = _appliedadService.FindById(item.id).Data;
                    var result = _appliedadService.Delete(deleteJob);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
               
                }
            }

            return BadRequest();

        }


        [HttpGet("findById")]
        public IActionResult FindById(int id)
        {
            var result = _appliedadService.FindById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }



        [HttpGet("getAll")]
        public IActionResult GetAllAppliedAdInfoDetails()
        {
            var result = _appliedadService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getAllAppliedAdInfoDetailsByAdId")]
        public IActionResult GetAllAppliedAdInfoDetails(int adId)
        {
            var result = _appliedadService.getAllDetailsWhoApplied(adId);
            if (result != null)
            {
                return Ok(result);

            }

            return BadRequest(); ;
        }
        [HttpGet("getAllAppliedAdInfoDetailsByUserId")]
        public IActionResult GetAllAppliedAdInfoDetailsByUserId(int userId)
        {
            var result = _appliedadService.GetAppliedAdDetailsByUserId(userId);
            if (result != null)
            {
                return Ok(result);

            }

            return BadRequest(); ;
        }

    }
}
