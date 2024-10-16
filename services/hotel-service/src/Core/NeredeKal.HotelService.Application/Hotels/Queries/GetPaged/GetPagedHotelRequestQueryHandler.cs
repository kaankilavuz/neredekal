using AutoMapper;
using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.SharedKernel.Services.DTOs;

namespace NeredeKal.HotelService.Application.Hotels.Queries.GetPaged
{
    public sealed class GetPagedHotelRequestQueryHandler : IRequestHandler<GetPagedHotelRequestQuery, PagedResponseDto<HotelDto>>
    {
        private IHotelRepository HotelRepository { get; }
        private IMapper Mapper { get; }

        public GetPagedHotelRequestQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            HotelRepository = hotelRepository;
            Mapper = mapper;
        }

        public async Task<PagedResponseDto<HotelDto>> Handle(GetPagedHotelRequestQuery request, CancellationToken cancellationToken)
        {
            var hotels = await HotelRepository.GetPagedListAsync(request.Filter, request.SkipCount, request.MaxResultCount, cancellationToken);
            var totalCount = await HotelRepository.GetCountAsync(request.Filter, cancellationToken);

            var mappedHotels = Mapper.Map<List<HotelDto>>(hotels);
            return new PagedResponseDto<HotelDto>(mappedHotels, totalCount);
        }
    }
}
