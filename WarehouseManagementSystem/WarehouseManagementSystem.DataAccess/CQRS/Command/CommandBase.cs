using System.Threading.Tasks;

namespace DataAccess.CQRS.Command
{
    public abstract class CommandBase<T, TRepository>
    {
        public T Parameter { get; set; }

        public abstract Task Execute(TRepository repository);
    }
}
