using AutoMapper;
using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.HotelService.Domain.ValueObjects;
using NeredeKal.SharedKernel.Uow;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Update
{
    public sealed class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, HotelDto>
    {
        private IHotelRepository HotelRepository { get; }
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            HotelRepository = hotelRepository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<HotelDto> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel? hotel = await HotelRepository.FindAsync(request.Id!.Value, cancellationToken);

            if (hotel is null)
                throw new NullReferenceException(typeof(Hotel).Name);

            Location location = Location.Create(
                request.ContactInformation.City,
                request.ContactInformation.District,
                request.ContactInformation.Address);

            if (!hotel.Location.Equals(location))
                hotel.SetLocation(location);

            ContactInformation contactInformation = ContactInformation.Create(
                request.ContactInformation.Email,
                request.ContactInformation.Phone);

            if (!hotel.ContactInformation.Equals(contactInformation))
                hotel.SetContactInformation(contactInformation);

            hotel.SetName(request.Name);
            hotel.SetContactName(request.ContactName);
            hotel.SetContactSurname(request.ContactSurname);
            hotel.IsActive = request.IsActive;

            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return Mapper.Map<HotelDto>(hotel);
        }
    }
}
