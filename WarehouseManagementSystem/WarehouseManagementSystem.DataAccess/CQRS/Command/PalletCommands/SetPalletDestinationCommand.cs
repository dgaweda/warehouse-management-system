using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.Extensions;
using DataAccess.Repository.PalletRepository;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class SetPalletDestinationCommand : CommandBase<Pallet, IPalletRepository>
    {
        public override async Task Execute(IPalletRepository palletRepository)
        {
            var pallet = await palletRepository.GetByIdAsync(Parameter.Id);

            pallet.SetProperties(Parameter);
            pallet.SetStatus();

            await palletRepository.UpdateAsync(pallet);
        }
    }
}
