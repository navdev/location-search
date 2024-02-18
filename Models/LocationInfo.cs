
namespace LocationSearch.Models
{
    public class LocationInfo
    {
        public int ID { get; set; }
        public string LocationName { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly EndingTime { get; set; }
    }
}