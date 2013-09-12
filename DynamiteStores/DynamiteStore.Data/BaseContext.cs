using System.Data.Entity;

namespace DynamiteStore.Data
{
    public class BaseContext<TContext>
     : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        protected BaseContext()
            : base("name=DynamiteStores")
        { }
    }
}
