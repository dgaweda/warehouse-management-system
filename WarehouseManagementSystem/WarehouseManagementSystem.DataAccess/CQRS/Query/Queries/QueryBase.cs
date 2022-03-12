using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(WMSDatabaseContext context);
    }
}
