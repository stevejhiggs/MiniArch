using System.Data.Common;

namespace MiniArch.Persistance
{
	public partial class MiniArchDatabaseContext
	{
		public MiniArchDatabaseContext(DbConnection connection) : base(connection, true)
		{
			this.Configuration.LazyLoadingEnabled = false;
		}
	}
}
