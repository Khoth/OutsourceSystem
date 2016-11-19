using OutsourceSystem.Common.Dto.Login;
using OutsourceSystem.Common.Helpers;
using OutsourceSystem.Api.Business.Models.Login;

namespace OutsourceSystem.Api.Business.Mappers
{
    public static class LoginMapper
    {
        public static OutsourcerLoginRequest Map(OutsourcerLoginRequestDto dto)
        {
            return AutoMapper.Map<OutsourcerLoginRequestDto, OutsourcerLoginRequest>(dto);
        }

        public static OutsourcerLoginResponseDto Map(OutsourcerLoginResponse domain)
        {
            return AutoMapper.Map<OutsourcerLoginResponse, OutsourcerLoginResponseDto>(domain);
        }
    }
}