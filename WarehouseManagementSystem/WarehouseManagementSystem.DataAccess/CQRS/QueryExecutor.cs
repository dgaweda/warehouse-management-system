using DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly WMSDatabaseContext context;
        public QueryExecutor(WMSDatabaseContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query) => query.Execute(context);
    }
}
