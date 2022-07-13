#nullable enable
using System;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Command
{
    public abstract class CommandBase<TParameter, TResult, TRepository>
    {
        public TParameter Parameter { get; set; }

        public abstract Task<TResult> Execute(TRepository repository);
    }
}
