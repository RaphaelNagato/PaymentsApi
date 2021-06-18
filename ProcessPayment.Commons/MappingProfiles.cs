using AutoMapper;
using ProcessPayment.Dto;
using ProcessPayment.Models;

namespace ProcessPayment.Commons
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PaymentDetailsDto, Payment>();
        }
    }
}
