using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;

namespace NeredeKal.HotelService.Application.Hotels.Queries.GetById
{
    public record GetHotelByIdQuery(Guid Id) : IRequest<HotelDto>;
}
