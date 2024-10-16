using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeredeKal.HotelService.Application.Hotels.Commands.Create;
using NeredeKal.HotelService.Application.Hotels.Commands.Delete;
using NeredeKal.HotelService.Application.Hotels.Commands.Update;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Application.Hotels.Queries.GetById;
using NeredeKal.HotelService.Application.Hotels.Queries.GetPaged;
using NeredeKal.SharedKernel.Services.DTOs;

namespace NeredeKal.HotelService.Api.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public sealed class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public Task<HotelDto> GetHotelById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetHotelByIdQuery(id);
            return _mediator.Send(query, cancellationToken);
        }

        [HttpGet("paged")]
        public Task<PagedResponseDto<HotelDto>> GetPagedHotels([FromQuery] GetPagedHotelRequestQuery filter, CancellationToken cancellationToken)
        {
            return _mediator.Send(filter, cancellationToken);
        }

        [HttpPost]
        public Task<HotelDto> CreateHotel([FromBody] CreateHotelCommand input, CancellationToken cancellationToken)
        {
            return _mediator.Send(input, cancellationToken);
        }

        [HttpPut("{id:guid}")]
        public Task<HotelDto> UpdateHotel(Guid id, [FromBody] UpdateHotelCommand input, CancellationToken cancellationToken)
        {
            input.Id = id;
            return _mediator.Send(input, cancellationToken);
        }

        [HttpDelete("{id:guid}")]
        public Task<Guid> DeleteHotel(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteHotelCommand(id);
            return _mediator.Send(command, cancellationToken);
        }
    }
}
