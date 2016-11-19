using OutsourceSystem.Common.Dto.Registration;
using OutsourceSystem.Common.Helpers;
using OutsourceSystem.Api.Business.Models.Registration;

namespace OutsourceSystem.Api.Business.Mappers
{
    public static class RegistrationMapper
    {
        public static OutsourcerRegistrationRequest Map(OutsourcerRegistrationRequestDto dto)
        {
            return AutoMapper.Map<OutsourcerRegistrationRequestDto, OutsourcerRegistrationRequest>(dto);
        }

        public static OutsourcerRegistrationResponseDto Map(OutsourcerRegistrationResponse domain)
        {
            return AutoMapper.Map<OutsourcerRegistrationResponse, OutsourcerRegistrationResponseDto>(domain);
        }
    }
}