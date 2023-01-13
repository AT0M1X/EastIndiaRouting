using CESAPI.Context;
using CESAPI.Data;
using CESAPI.DTOs;
using CESAPI.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CESAPI.Service
{
    public class AuthenticateService
    {
        private readonly UserDao _userDao;
        public AuthenticateService(ICityMapper cityMapper, IServiceScopeFactory serviceScopeFactory)
        {
            _userDao = new UserDao(serviceScopeFactory);
        }

        public bool Authenticate(string username, string password)
        {
            var user = _userDao.GetUser(username);
            if (user == null) return false;
            return user.Password == password;
        }
    }
}
