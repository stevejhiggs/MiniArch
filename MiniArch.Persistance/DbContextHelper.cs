using System.Data.Entity;

namespace MiniArch.Persistance
{
	public static class DbContextHelper
	{
		public static T GetLightweightDbContext<T>() where T: DbContext, new()
		{
			T dbContext = new T();
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			dbContext.Configuration.LazyLoadingEnabled = false;
			dbContext.Configuration.ProxyCreationEnabled = false;
			return dbContext;
		}
	}
}
