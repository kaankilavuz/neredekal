using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using System.Text.Json.Serialization;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Update
{
    public record UpdateHotelCommand : CreateOrUpdateHotelBaseInput, IRequest<HotelDto>
    {
        [JsonIgnore]
        public Guid? Id { get; set; } = null;
        public CreateContactInformationInput ContactInformation { get; init; }
    }
}
