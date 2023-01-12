using EIT.Data;
using EIT.DTOs;
using EIT.Mappers;
using System.Collections.Generic;

namespace EIT.Service
{
    public class PackageTypeService
    {
        private readonly IPackageTypeMapper _packageTypeMapper;
        private readonly PackageTypeDao _packageTypeDao;

        public PackageTypeService(IPackageTypeMapper packageTypeMapper, PackageTypeDao packageTypeDao)
        {
            _packageTypeMapper = packageTypeMapper;
            _packageTypeDao = packageTypeDao;
        }

        public List<PackageTypeDto> GetPackageTypes()
        {
            var packageTypeModels = _packageTypeDao.GetAllPackageTypes();
            return _packageTypeMapper.MapPackageTypeModelsToDtos(packageTypeModels);
        }

        public PackageTypeDto GetPackageType(string packageType)
        {
            var packageTypeModel = _packageTypeDao.GetPackageType(packageType);
            return _packageTypeMapper.MapPackageTypeModelToDto(packageTypeModel);
        }
    }
}
