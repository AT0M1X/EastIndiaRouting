using EIT.DTOs;
using EIT.Mappers;

namespace EIT.Service
{
    public class RoleService
    {
        private readonly IRoleMapper _roleMapper;

        public RoleService(IRoleMapper roleMapper)
        {
            _roleMapper = roleMapper;
        }

        public RoleDto GetRole()
        {
            return _roleMapper.mapRoleModelToDto();
        }
    }
}
