using System.Threading.Tasks;
using DataAccess.Entities.EntityBases;

namespace DataAccess.CQRS.Command
{
    public abstract class CommandBase<TEntity, TRepository>
    {
        public TEntity Parameter { get; set; }

        public abstract Task<TEntity> Execute(TRepository repository);
    }
}
