using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Repository.PalletRepository;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class AddPalletCommand : CommandBase<Pallet, IPalletRepository>
    {
        public override async Task Execute(IPalletRepository palletRepository)
        {
            await palletRepository.AddAsync(Parameter);
        }
    }
}
