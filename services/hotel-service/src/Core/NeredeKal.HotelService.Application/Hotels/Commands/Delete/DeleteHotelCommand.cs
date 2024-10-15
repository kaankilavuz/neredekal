using MediatR;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Delete
{
    public record DeleteHotelCommand(Guid Id) : IRequest<Guid>;
}
