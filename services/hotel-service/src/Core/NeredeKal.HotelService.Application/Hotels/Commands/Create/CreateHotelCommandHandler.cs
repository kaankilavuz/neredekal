using AutoMapper;
using MediatR;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.SharedKernel.Uow;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Create
{
    public sealed class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, HotelDto>
    {
        private IHotelRepository HotelRepository { get; }
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public CreateHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            HotelRepository = hotelRepository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            HotelBuilder hotelBuilder = new();
            hotelBuilder.WithLocation(request.ContactInformation.City, request.ContactInformation.District, request.ContactInformation.Address)
                .WithContactInformation(request.ContactInformation.Email, request.ContactInformation.Phone)
                .WithHotelDetails(request.Name, request.ContactName, request.ContactSurname, request.IsActive);

            Hotel hotel = hotelBuilder.Build();

            var createdHotel = await HotelRepository.InsertAsync(hotel, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapper.Map<HotelDto>(createdHotel);
        }
    }
}
