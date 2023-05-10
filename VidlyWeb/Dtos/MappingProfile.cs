using AutoMapper;
using VidlyWeb.Models;

namespace VidlyWeb.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
