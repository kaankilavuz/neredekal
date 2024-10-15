using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commands.Create;
using NeredeKal.HotelService.Application.Hotels.Commands.Delete;
using NeredeKal.HotelService.Application.Hotels.Commands.Update;
using NeredeKal.HotelService.Application.Hotels.Queries.GetById;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;

namespace NeredeKal.HotelService.Api.Routers.Hotels
{
    public class HotelRouter
    {
        public static void MapHotelRoutes(IEndpointRouteBuilder app)
        {
            var hotels = app.MapGroup("/api/hotels");

            hotels.MapGet("{id:guid}", (IMediator mediator, Guid id, CancellationToken cancellationToken) =>
            {
                var query = new GetHotelByIdQuery(id);
                return mediator.Send(query, cancellationToken);
            });

            hotels.MapPost("", (IMediator mediator, CreateHotelCommand input, CancellationToken cancellationToken) =>
            {
                return mediator.Send(input, cancellationToken);
            });

            hotels.MapPut("{id:guid}", (IMediator mediator, Guid id, UpdateHotelCommand input, CancellationToken cancellationToken) =>
            {
                input.Id = id;
                return mediator.Send(input, cancellationToken);
            });

            hotels.MapDelete("{id:guid}", (IMediator mediator, Guid id, CancellationToken cancellationToken) =>
            {
                var command = new DeleteHotelCommand(id);
                return mediator.Send(command, cancellationToken);
            });
        }
    }
}
