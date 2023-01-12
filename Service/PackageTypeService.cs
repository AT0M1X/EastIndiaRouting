using EIT.DTOs;
using EIT.Mappers;
using System.Collections.Generic;

namespace EIT.Service
{
    public class PackageTypeService
    {
        private readonly IPackageTypeMapper _packageTypeMapper;

        public PackageTypeService(IPackageTypeMapper packageTypeMapper)
        {
            _packageTypeMapper = packageTypeMapper;
        }

        public List<PackageTypeDto> GetPackageTypes()
        {
            return _packageTypeMapper.MapPackageTypeModelsToDtos();
        }

        public PackageTypeDto GetPackageType(string packageType)
        {
            return new PackageTypeDto();
        }
    }
}
