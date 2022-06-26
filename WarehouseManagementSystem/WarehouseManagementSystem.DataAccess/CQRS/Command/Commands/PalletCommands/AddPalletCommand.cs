using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class AddPalletCommand : CommandBase<Pallet, Pallet>
    {
        public override async Task<Pallet> Execute(IRepository<Pallet> palletRepository)
        {
            await palletRepository.AddAsync(Parameter);
            return Parameter;
        }
    }
}
