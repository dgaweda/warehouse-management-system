using System.Threading.Tasks;

namespace DataAccess.CQRS.Query.Queries
{
    public abstract class QueryBase<TEntity, TRepository>
    {
        public abstract Task<TEntity> Execute(TRepository repository);
    }
}
