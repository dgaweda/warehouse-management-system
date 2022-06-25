using DataAccess.CQRS.Commands;
using System.Threading.Tasks;
using DataAccess.Entities.EntityBases;
using DataAccess.Repository;

namespace DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command, IRepository<TParameters> repositoryService) 
            where TParameters : class, IEntityBase;
    }
}
