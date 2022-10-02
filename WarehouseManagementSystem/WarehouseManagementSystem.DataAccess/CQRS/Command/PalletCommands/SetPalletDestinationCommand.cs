using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.PalletRepository;

namespace DataAccess.CQRS.Command.PalletCommands
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
