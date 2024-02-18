
using LocationSearch.Models;
using LocationSearch.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocationSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private ILocationService _locationService { get; set; }

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("search")]
        public ActionResult<Result<IEnumerable<LocationInfo>>> Search(string openingTime, string endingTime)
        {
            var openingTimeValue = TimeOnly.Parse(openingTime);
            var endingTimeValue = TimeOnly.Parse(endingTime);
            var locations = _locationService.GetLocations();
            return new Result<IEnumerable<LocationInfo>>()
            {
                Data = locations.Where(x => x.OpeningTime >= openingTimeValue && x.OpeningTime <= endingTimeValue)
            };
        }

        [HttpGet]
        [Route("availablebetween10amand1pm")]
        public ActionResult<Result<IEnumerable<LocationInfo>>> AvailableBetween10AMAnd1PM()
        {
            var openingTimeValue = TimeOnly.Parse("10:00");
            var endingTimeValue = TimeOnly.Parse("13:00");
            var locations = _locationService.GetLocations();
            return new Result<IEnumerable<LocationInfo>>()
            {
                Data = locations.Where((x => (x.OpeningTime >= openingTimeValue && x.OpeningTime <= endingTimeValue) || (x.OpeningTime <= endingTimeValue)))
            };
        }
    }
}