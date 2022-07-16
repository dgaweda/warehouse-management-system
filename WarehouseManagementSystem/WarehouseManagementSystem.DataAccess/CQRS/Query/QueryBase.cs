using System.Threading.Tasks;

namespace DataAccess.CQRS.Query
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute();
    }
}
