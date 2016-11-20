using OutsourceSystem.Common.Dto.Base;
using OutsourceSystem.Common.Dto.Login;
using OutsourceSystem.Common.Dto.Registration;
using System.Threading.Tasks;

namespace OutsourceSystem.Api.Client.Services
{
    public class AccountService : ServiceBase
    {
        private AccountService() : base("http://localhost:52084/api/v1/Account") { }

        public Task<ResponseBaseDto<OutsourcerLoginResponseDto>> LoginOutsourcer(OutsourcerLoginRequestDto dto)
        {
            return PostAsync<ResponseBaseDto<OutsourcerLoginResponseDto>>("LoginOutsourcer", content: dto);
        }

        public Task<ResponseBaseDto<OutsourcerRegistrationResponseDto>> RegisterOutsourcer(OutsourcerRegistrationRequestDto dto)
        {
            return PostAsync<ResponseBaseDto<OutsourcerRegistrationResponseDto>>("RegisterOutsourcer", content: dto);
        }
    }
}