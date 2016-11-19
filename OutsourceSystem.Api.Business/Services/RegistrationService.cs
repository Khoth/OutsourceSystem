using OutsourceSystem.Api.Business.Dao;
using OutsourceSystem.Api.Business.Models.Registration;
using OutsourceSystem.Api.Business.Resources;

namespace OutsourceSystem.Api.Business.Services
{
    public static class RegistrationService
    {
        public static OutsourcerRegistrationResponse RegisterOutsourcer(OutsourcerRegistrationRequest request)
        {
            if (OutsourcerDao.IsBusy(request.Login))
            {
                return new OutsourcerRegistrationResponse
                {
                    Id = 0,
                    Message = Messages.OutsourcerLoginIsBusy
                };
            }

            return OutsourcerDao.Create(request);
        }
    }
}