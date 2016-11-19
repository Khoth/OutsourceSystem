﻿using OutsourceSystem.Common.Helpers;

namespace OutsourceSystem.Api.Business.Models.Registration
{
    public class OutsourcerRegistrationRequest
    {
        private string password;

        public string Login { get; set; }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                PasswordHash = Cryptography.CreateMD5(password);
            }
        }

        public string PasswordHash { get; private set; }
    }
}