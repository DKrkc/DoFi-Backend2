using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet("getbycityid")]
        public IActionResult GetByCityId(int cityId)
        {
            var result = _regionService.FindByCityId(cityId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getAllRegions")]
        public IActionResult GetByCityId()
        {
            var result = _regionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
