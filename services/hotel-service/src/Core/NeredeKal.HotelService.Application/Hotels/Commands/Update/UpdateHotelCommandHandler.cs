using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.SharedKernel.Uow;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Update
{
    public sealed class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, HotelDto>
    {
        private IHotelRepository HotelRepository { get; }
        private IUnitOfWork UnitOfWork { get; }

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            HotelRepository = hotelRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<HotelDto> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel? hotel = await HotelRepository.FindAsync(request.Id, cancellationToken);

            if (hotel is null)
                return new HotelDto();

            hotel.SetName(request.Name);
            hotel.SetContactName(request.ContactName);
            hotel.SetContactSurname(request.ContactSurname);
            hotel.IsActive = request.IsActive;

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
