using AutoMapper;
using BarManagerA.Models.DTO;
using BarManagerA.Models.Requests;
using BarManagerA.Models.Responses;

namespace BarManagerA.Host.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Tag, TagResponse>()
                .ForMember(m => m.SpecialName, tm => tm.MapFrom(x => x.Id + x.Name));
            CreateMap<TagRequest, Tag>();

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(m => m.Id, tm => tm.MapFrom(x => x.Id + x.Name));
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<Bill, BillResponse>();
            CreateMap<BillRequest, Bill>();
            CreateMap<Products, ProductsResponse>()
                .ForMember(m => m.Id, tm => tm.MapFrom(x => x.Id + x.Name));
            CreateMap<ProductsRequest, Products>();
        }
    }
}
