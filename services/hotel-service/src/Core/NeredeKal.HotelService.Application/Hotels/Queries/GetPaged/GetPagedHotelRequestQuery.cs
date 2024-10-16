using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.SharedKernel.Services.DTOs;

namespace NeredeKal.HotelService.Application.Hotels.Queries.GetPaged
{
    public class GetPagedHotelRequestQuery : GetPagedAndSortedResultRequestInput, IRequest<PagedResponseDto<HotelDto>>
    {
        public string Filter { get; init; } = string.Empty;
    }
}
