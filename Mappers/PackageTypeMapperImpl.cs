using EIT.DTOs;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public class PackageTypeMapperImpl : IPackageTypeMapper
    {
        public PackageTypeDto MapPackageTypeModelToDto()
        {
            return new PackageTypeDto() { Id = 1, Name = "Test"};
        }

        public List<PackageTypeDto> MapPackageTypeModelsToDtos()
        {
            var packageTypes = new List<PackageTypeDto>();

            return packageTypes;
        }
    }
}
