using CESAPI.DTOs;
using CESAPI.Model;
using System.Collections.Generic;

namespace CESAPI.Mappers
{
    public class PackageTypeMapperImpl : IPackageTypeMapper
    {
        public PackageTypeDto MapPackageTypeModelToDto(PackageType packageType)
        {
            if (packageType == null)
            {
                return null;
            }
            return new PackageTypeDto() { Id = packageType.PackageTypeID, Name = packageType.PackageTypeName, Supported = packageType.Supported};
        }

        public List<PackageTypeDto> MapPackageTypeModelsToDtos(List<PackageType> packageTypes)
        {
            var packageTypeDtos = new List<PackageTypeDto>();
            foreach (var packageType in packageTypes)
            { 
                packageTypeDtos.Add(MapPackageTypeModelToDto(packageType)); 
            }

            return packageTypeDtos;
        }
    }
}
