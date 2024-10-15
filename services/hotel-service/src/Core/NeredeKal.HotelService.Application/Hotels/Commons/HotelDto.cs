using NeredeKal.SharedKernel.Entities.Abstracts;

namespace NeredeKal.HotelService.Application.Hotels.Commons
{
    //TODO: Base DTOs
    public class HotelDto : ISoftDelete
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ContactName { get; init; } = string.Empty;
        public string ContactSurname { get; init; } = string.Empty;
        public ContactInformationDto ContactInformation { get; init; }
        public LocationDto Location { get; init; }
        public bool IsActive { get; init; }
        public bool IsDeleted { get; init; }
        public DateTime? DeletionTime { get; init; }
        public DateTime? LastModificationTime { get; init; }
        public DateTime CreationTime { get; init; }
    }
}
