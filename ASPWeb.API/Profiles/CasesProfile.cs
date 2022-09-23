using AutoMapper;

namespace ASPWeb.API.Profiles
{
    public class CasesProfile: Profile
    {
        public CasesProfile()
        {
            CreateMap<Models.Domain.Case, Models.DTO.Case>()
                .ReverseMap();

        }
    }
}
