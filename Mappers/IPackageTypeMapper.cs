using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface IPackageTypeMapper
    {
        public PackageTypeDto MapPackageTypeModelToDto(PackageType packageType);

        public List<PackageTypeDto> MapPackageTypeModelsToDtos(List<PackageType> packageTypes);
    }
}
