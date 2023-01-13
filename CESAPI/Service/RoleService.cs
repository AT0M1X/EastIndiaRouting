using CESAPI.DTOs;
using CESAPI.Mappers;

namespace CESAPI.Service
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
            return _roleMapper.MapRoleModelToDto();
        }
    }
}
