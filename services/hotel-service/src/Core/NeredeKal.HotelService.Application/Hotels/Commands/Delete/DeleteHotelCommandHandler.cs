using MediatR;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.SharedKernel.Uow;

namespace NeredeKal.HotelService.Application.Hotels.Commands.Delete
{
    public sealed class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, Guid>
    {
        private IHotelRepository HotelRepository { get; }
        private IUnitOfWork UnitOfWork { get; }

        public DeleteHotelCommandHandler(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            HotelRepository = hotelRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            Hotel? hotel = await HotelRepository.FindAsync(request.Id, cancellationToken);

            if (hotel is null)
                throw new NullReferenceException(nameof(Hotel));
            //TODO:Soft delete
            await HotelRepository.ExecuteDeleteAsync(hotel, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return hotel.Id;
        }
    }
}
