using System.Collections;
using System.Collections.Generic;
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
                .ForMember(m => m.SpecialName, tm => tm.MapFrom(x => x.Id + x.Name))
                .ReverseMap();
            CreateMap<TagRequest, Tag>().ReverseMap();
            //CreateMap<IEnumerable<Tag>, IEnumerable<TagResponse>>().ReverseMap();

            CreateMap<Employee, EmployeeResponse>()
                .ForMember(m => m.Id, tm => tm.MapFrom(x => x.Id + x.Name))
                .ReverseMap();
            CreateMap<EmployeeRequest, Employee>().ReverseMap();
            CreateMap<Bill, BillResponse>();
            CreateMap<BillRequest, Bill>();
            CreateMap<Products, ProductsResponse>()
                .ForMember(m => m.Id, tm => tm.MapFrom(x => x.Id + x.Name));             
            CreateMap<ProductsRequest, Products>()
             .ReverseMap();
        }
    }
}
