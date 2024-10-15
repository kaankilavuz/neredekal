using AutoMapper;
using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.SharedKernel.Uow;

namespace NeredeKal.HotelService.Application.Hotels.Queries.GetById
{
    public sealed class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelDto>
    {
        private IHotelRepository HotelRepository { get; }
        private IMapper Mapper { get; }

        public GetHotelByIdQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            HotelRepository = hotelRepository;
            Mapper = mapper;
        }

        public async Task<HotelDto> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await HotelRepository.FindAsync(request.Id, cancellationToken);
            return Mapper.Map<HotelDto>(hotel);
        }
    }
}
