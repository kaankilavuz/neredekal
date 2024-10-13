using MediatR;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Delete
{
    public record DeleteHotelCommand : IRequest<Guid>
    {
        public Guid Id { get; init; }
    }
}
