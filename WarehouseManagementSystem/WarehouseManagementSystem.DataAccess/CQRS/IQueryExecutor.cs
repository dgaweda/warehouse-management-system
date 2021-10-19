using DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
