using System.Threading.Tasks;

namespace DataAccess.CQRS.Query.Queries
{
    public abstract class QueryBase<TResult, TRepository>
    {
        public abstract Task<TResult> Execute(TRepository repository);
    }
}
