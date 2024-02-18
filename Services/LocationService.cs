
using CsvHelper;
using LocationSearch.Models;
using Microsoft.VisualBasic;

namespace LocationSearch.Services
{
    public class LocationService : ILocationService
    {
        private IEnumerable<LocationInfo> _locationData { get; set; }
        private readonly ICSVService _csvService;
        private readonly IWebHostEnvironment _environment;
        public LocationService(ICSVService csvService, IWebHostEnvironment environment)
        {
            _csvService = csvService;
            _environment = environment;
            LoadLocations();
        }

        public IEnumerable<LocationInfo> GetLocations()
        {
            return _locationData;
        }

        private void LoadLocations()
        {
            List<LocationInfo> locations = new List<LocationInfo>();
            var filePath = Path.Combine(_environment.ContentRootPath, "locationdata.csv");
            if (!File.Exists(filePath)) return;
            using (var file = File.OpenRead(filePath))
            {
                locations.AddRange(_csvService.ReadCSV<LocationInfo>(file));
                _locationData = locations;
                //locations.Select(x => new LocationInfo()
                //{
                //    ID = x.ID,
                //    LocationName = x.LocationName,
                //    OpeningTime = x.OpeningTime,
                //    EndingTime = x.OpeningTime
                //});
            }
        }
    }
}