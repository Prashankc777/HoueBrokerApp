using AutoMapper;
using HouseBrokerMVP.Business.DTO;
using HouseBrokerMVP.Business.Exceptions;
using HouseBrokerMVP.Core.Entities;
using HouseBrokerMVP.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HouseBrokerMVP.Business.Services
{
    public class PropertyTypeService(
        IPropertyTypeReposiotry propertyTypeReposiotry,
        IMapper mapper,
        IHttpContextAccessor contextAccessor)
        : IPropertyTypeService
    {
        public IHttpContextAccessor _contextAccessor = contextAccessor;

        public async Task<PropertyTypeListDto> Create(PropertyTypeInsertDto data)
        {
            var model = mapper.Map<PropertyType>(data);
            await propertyTypeReposiotry.Insert(model);
            await propertyTypeReposiotry.SaveChanges();
            return mapper.Map<PropertyTypeListDto>(model);
        }

        public async Task<PropertyTypeListDto> Update(PropertyTypeUpdateDto data)
        {
            var serviceData = await propertyTypeReposiotry.GetById(data.Id, true).FirstOrDefaultAsync();
            if (serviceData == null)
                throw new NotFoundException("Property Type not Found");
            serviceData.Name = data.Name;
            propertyTypeReposiotry.Update(serviceData);
            await propertyTypeReposiotry.SaveChanges();
            return mapper.Map<PropertyTypeListDto>(serviceData);
        }

        public async Task Delete(int id)
        {
            var data = await propertyTypeReposiotry.GetById(id, true).FirstOrDefaultAsync();
            if (data == null)
                throw new NotFoundException("Property Type not Found");
            await propertyTypeReposiotry.RemoveById(data.Id);
        }

        public async Task<IEnumerable<PropertyTypeListDto>> GetList()
        {
            var data = await propertyTypeReposiotry.Get().ToListAsync();
            var mappedData = mapper.Map<IEnumerable<PropertyTypeListDto>>(data);
            return mappedData;
        }

        public async Task<PropertyTypeListDto> GetById(int id)
        {
            var originalData = await propertyTypeReposiotry.GetById(id).FirstOrDefaultAsync();
            if (originalData == null)
                throw new NotFoundException("Property Type not Found");
            return mapper.Map<PropertyTypeListDto>(originalData);
        }
    }
}
