using AutoMapper;
using ProductSupport.API.DTOs.CompaniesDTO;
using ProductSupport.API.DTOs.ProductsDTO;
using ProductSupport.API.Models;
using ProductSupport.Models;

namespace ProductSupport.API.Mapper
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            #region From Product To ViewProductDTO
            CreateMap<Product, ViewProductDTO>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CompanyID, opt => opt.MapFrom(src => src.CompanyID))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath));
            #endregion

            #region From Product To ViewProductDTO
            CreateMap<ViewProductDTO , Product>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CompanyID, opt => opt.MapFrom(src => src.CompanyID))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath));
            #endregion

            #region From Company To ViewCompanyDTO
            CreateMap<Company, ViewCompanyDTO>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Imagepath));
            #endregion

            #region From Company To ViewCompanyDTO
            CreateMap<ViewCompanyDTO, Company>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Imagepath, opt => opt.MapFrom(src => src.ImagePath));
            #endregion
        }
    }
}
