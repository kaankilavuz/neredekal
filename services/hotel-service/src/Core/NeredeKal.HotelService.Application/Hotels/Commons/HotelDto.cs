namespace NeredeKal.HotelService.Application.Hotels.Commons
{
    public record HotelDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string ContactName { get; init; }
        public string ContactSurname { get; init; }
        public bool IsActive { get; init; }
        public bool IsDeleted { get; init; }
    }
}
