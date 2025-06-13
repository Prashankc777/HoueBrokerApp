
using HouseBrokerMVP.Core.Entities;

namespace HouseBrokerMVP.Core.Repositories
{

    public interface IPropertyImageReposiotry : IRepositoryBase<PropertyImage, int>
    {
        IQueryable<PropertyImage> GetByPropertyId(int propertyId, bool TrackEntity);
        Task Delete(int id);
        Task DeleteByPropertyId(int id);
      
    }
}
