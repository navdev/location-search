using LocationSearch.Models;

namespace LocationSearch.Services
{
    public interface ILocationService
    {
        IEnumerable<LocationInfo> GetLocations();
    }
}