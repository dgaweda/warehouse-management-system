using DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
