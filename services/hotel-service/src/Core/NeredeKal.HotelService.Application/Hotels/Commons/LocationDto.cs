namespace NeredeKal.HotelService.Application.Hotels.Commons
{
    public record LocationDto
    {
        public string City { get; init; }
        public string District { get; init; }
        public string Address { get; init; }
    }
}
