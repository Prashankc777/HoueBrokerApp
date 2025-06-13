using HouseBrokerMVP.Core.Context;
using HouseBrokerMVP.Core.Entities;
using HouseBrokerMVP.Core.Repositories;

namespace HouseBrokerMVP.Infrastructure.Repository
{
    public class PropertyRepository : RepositoryBase<Property, int>, IPropertyReposiotry
    {
        public PropertyRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
