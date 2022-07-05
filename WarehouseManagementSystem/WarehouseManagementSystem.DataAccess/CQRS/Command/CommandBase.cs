using System.Threading.Tasks;

namespace DataAccess.CQRS.Command.Commands
{
    public abstract class CommandBase<T, TRepository>
    {
        public T Parameter { get; set; }

        public abstract Task<T> Execute(TRepository repository);
    }
}
