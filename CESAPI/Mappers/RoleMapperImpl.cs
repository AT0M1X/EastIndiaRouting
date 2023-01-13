using CESAPI.DTOs;

namespace CESAPI.Mappers
{
    public class RoleMapperImpl : IRoleMapper
    {
        public RoleDto MapRoleModelToDto()
        {
            return new RoleDto();
        }
    }
}
