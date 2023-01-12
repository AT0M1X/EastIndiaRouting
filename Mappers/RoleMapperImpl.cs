using EIT.DTOs;

namespace EIT.Mappers
{
    public class RoleMapperImpl : IRoleMapper
    {
        public RoleDto MapRoleModelToDto()
        {
            return new RoleDto();
        }
    }
}
