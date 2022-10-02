using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.PalletRepository;

namespace DataAccess.CQRS.Command.PalletCommands
{
    public class RemovePalletCommand : CommandBase<Pallet, IPalletRepository>
    {
        public override async Task Execute(IPalletRepository palletRepository)
        {
            await palletRepository.DeleteAsync(Parameter.Id);
        }
    }
}
