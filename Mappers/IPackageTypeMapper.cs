using EIT.DTOs;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface IPackageTypeMapper
    {
        public PackageTypeDto MapPackageTypeModelToDto();

        public List<PackageTypeDto> MapPackageTypeModelsToDtos();
    }
}
