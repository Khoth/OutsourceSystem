using OutsourceSystem.Common.Helpers;
using OutsourceSystem.Api.Business.Dao;
using OutsourceSystem.Api.Business.Models.Login;
using OutsourceSystem.Api.Business.Resources;

namespace OutsourceSystem.Api.Business.Services
{
    public static class LoginService
    {
        public static OutsourcerLoginResponse LoginOutsourcer(OutsourcerLoginRequest request)
        {
            var outsourcer = OutsourcerDao.Get(request);

            return new OutsourcerLoginResponse
            {
                Token = outsourcer == null ? null : Cryptography.ToBase64($"{outsourcer.Id}:{outsourcer.Login}"),
                Message = outsourcer == null ? Messages.OutsourcerLoginFailed : null
            };
        }
    }
}