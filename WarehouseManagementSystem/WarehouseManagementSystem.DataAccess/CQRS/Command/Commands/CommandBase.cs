using System.Threading.Tasks;
using DataAccess.Entities.EntityBases;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParameter, TResult>
        where TParameter : class, IEntityBase
    {
        public TParameter Parameter { get; set; }
        public abstract Task<TResult> Execute(IRepository<TParameter> repositoryService);
    }
}
