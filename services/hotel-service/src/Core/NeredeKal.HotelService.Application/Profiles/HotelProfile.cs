using AutoMapper;
using NeredeKal.HotelService.Application.Hotels.Commons;
using NeredeKal.HotelService.Domain.Aggregates.Hotels;
using NeredeKal.HotelService.Domain.ValueObjects;

namespace NeredeKal.HotelService.Application.Profiles
{
    public sealed class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<ContactInformation, ContactInformationDto>();
            CreateMap<Hotel, HotelDto>()
                .ForMember(m => m.Id, src => src.MapFrom(mf => mf.Id))
                .ForMember(m => m.CreationTime, src => src.MapFrom(mf => mf.CreationTime))
                .ForMember(m => m.LastModificationTime, src => src.MapFrom(mf => mf.LastModificationTime))
                .ForMember(m => m.DeletionTime, src => src.MapFrom(mf => mf.DeletionTime))
                .ForMember(m => m.IsActive, src => src.MapFrom(mf => mf.IsActive))
                .ForMember(m => m.IsDeleted, src => src.MapFrom(mf => mf.IsDeleted));
        }
    }
}
