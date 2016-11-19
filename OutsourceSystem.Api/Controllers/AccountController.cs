using OutsourceSystem.Api.Business.Mappers;
using OutsourceSystem.Api.Business.Services;
using OutsourceSystem.Common.Dto.Base;
using OutsourceSystem.Common.Dto.Login;
using OutsourceSystem.Common.Dto.Registration;
using System.Web.Http;

namespace OutsourceSystem.Api.Controllers
{
    [RoutePrefix("api/v1/Account")]
    public class AccountController : ApiController
    {
        [HttpPost, Route("LoginOutsourcer")]
        public ResponseBaseDto<OutsourcerLoginResponseDto> LoginOutsourcer(OutsourcerLoginRequestDto dto)
        {
            var requestDomain = LoginMapper.Map(dto);
            var responseDomain = LoginService.LoginOutsourcer(requestDomain);
            var responseDto = LoginMapper.Map(responseDomain);

            return string.IsNullOrEmpty(responseDto.Token)
                ? new ResponseBaseDto<OutsourcerLoginResponseDto> { Error = responseDomain.Message }
                : new ResponseBaseDto<OutsourcerLoginResponseDto> { Data = responseDto, IsSuccess = true };
        }

        [HttpPost, Route("RegisterOutsourcer")]
        public ResponseBaseDto<OutsourcerRegistrationResponseDto> RegisterOutsourcer(OutsourcerRegistrationRequestDto dto)
        {
            var requestDomain = RegistrationMapper.Map(dto);
            var responseDomain = RegistrationService.RegisterOutsourcer(requestDomain);
            var responseDto = RegistrationMapper.Map(responseDomain);

            return responseDto.Id == 0
                ? new ResponseBaseDto<OutsourcerRegistrationResponseDto> { Error = responseDomain.Message }
                : new ResponseBaseDto<OutsourcerRegistrationResponseDto> { Data = responseDto, IsSuccess = true };
        }
    }
}