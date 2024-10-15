using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Create
{
    public record CreateHotelCommand : CreateOrUpdateHotelBaseInput, IRequest<HotelDto>
    {
        public CreateContactInformationInput ContactInformation { get; init; }
    }
}
