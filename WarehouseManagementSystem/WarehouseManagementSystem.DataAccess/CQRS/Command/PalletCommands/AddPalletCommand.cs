using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repository.PalletRepository;

namespace DataAccess.CQRS.Command.PalletCommands
{
    public class AddPalletCommand : CommandBase<Pallet, IPalletRepository>
    {
        public override async Task Execute(IPalletRepository palletRepository)
        {
            await palletRepository.AddAsync(Parameter);
        }
    }
}
