using System.Threading.Tasks;

namespace DataAccess.CQRS.Command
{
    public abstract class CommandBase<TParameter, TRepository>
    {
        public TParameter Parameter { get; set; }

        public abstract Task Execute(TRepository repository);
    }
}
