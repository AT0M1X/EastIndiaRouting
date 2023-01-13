using CESAPI.DTOs;
using CESAPI.Model;
using System.Collections.Generic;

namespace CESAPI.Mappers
{
    public interface IPackageTypeMapper
    {
        public PackageTypeDto MapPackageTypeModelToDto(PackageType packageType);

        public List<PackageTypeDto> MapPackageTypeModelsToDtos(List<PackageType> packageTypes);
    }
}
