using EIT.Context;
using EIT.Data;
using EIT.DTOs;
using EIT.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace EIT.Service
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
