using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.SharedKernel.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Create
{
    public sealed class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, HotelDto>
    {
        private IHotelRepository HotelRepository { get; }
        private IUnitOfWork UnitOfWork { get; }

        public CreateHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            HotelRepository = hotelRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel hotel = new(request.Name,
                request.ContactName,
                request.ContactSurname,
                true);

            await HotelRepository.InsertAsync(hotel, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return new HotelDto
            {
                Id = hotel.Id,
                ContactName = hotel.ContactName,
                ContactSurname = hotel.ContactSurname,
                Name = hotel.Name,
                IsActive = hotel.IsActive,
                IsDeleted = hotel.IsDeleted
            };
        }
    }
}
