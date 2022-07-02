using DataAccess.CQRS.Commands;
using System.Threading.Tasks;
using DataAccess.Entities.EntityBases;
using DataAccess.Repository;

namespace DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command, IRepository<TParameter> repositoryService) 
            where TParameter : EntityBase;
    }
}
