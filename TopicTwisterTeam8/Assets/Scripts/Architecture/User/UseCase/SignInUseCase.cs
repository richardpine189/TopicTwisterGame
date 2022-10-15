﻿using System.Threading.Tasks;
using Architecture.User.Gateway;

namespace Architecture.User.UseCase
{
    public class SignInUseCase : ISignInUseCase
    {
        private IUserGateway _userGateway;

        public SignInUseCase(IUserGateway loginService)
        {
            _userGateway = loginService;
        }

        public async Task Invoke(string userName, string email)
        {
            var tempUser = await _userGateway.RequestSignIn(userName, email);

            // Loguear automaticamente cuando se registra?
        }
    }
}