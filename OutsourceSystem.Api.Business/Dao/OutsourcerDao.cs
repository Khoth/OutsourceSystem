using OutsourceSystem.Api.Business.Models.Login;
using OutsourceSystem.Api.Business.Models.Main;
using OutsourceSystem.Api.Business.Models.Registration;
using System.Collections.Generic;
using System.Linq;

namespace OutsourceSystem.Api.Business.Dao
{
    internal static class OutsourcerDao
    {
        private static readonly ICollection<Outsourcer> outsourcers = new List<Outsourcer>
        {
            new Outsourcer { Id = 1, Login = "vasya", PasswordHash = "827CCB0EEA8A706C4C34A16891F84E7B" }, // password = "12345"
            new Outsourcer { Id = 2, Login = "petya", PasswordHash = "A384B6463FC216A5F8ECB6670F86456A" }  // password = "qwert"
        };

        public static Outsourcer Get(OutsourcerLoginRequest request)
        {
            return outsourcers.FirstOrDefault(outsourcer => outsourcer.Login == request.Login &&
                                                            outsourcer.PasswordHash == request.PasswordHash);
        }

        public static OutsourcerRegistrationResponse Create(OutsourcerRegistrationRequest request)
        {
            var newOutsourcer = new Outsourcer
            {
                Id = outsourcers.Max(outsourcer => outsourcer.Id) + 1,
                Login = request.Login,
                PasswordHash = request.PasswordHash
            };
            outsourcers.Add(newOutsourcer);

            return new OutsourcerRegistrationResponse { Id = newOutsourcer.Id };
        }

        public static bool IsBusy(string login)
        {
            return outsourcers.Any(outsourcer => outsourcer.Login == login);
        }
    }
}