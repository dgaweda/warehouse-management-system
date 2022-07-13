using System.Linq;
using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Extensions;
using DataAccess.Repository;
using DataAccess.Repository.PalletRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class SetPalletDestinationCommand : CommandBase<Pallet, Pallet, IPalletRepository>
    {
        public override async Task<Pallet> Execute(IPalletRepository palletRepository)
        {
            var pallet = await palletRepository.GetByIdAsync(Parameter.Id);

            pallet.SetProperties(Parameter);
            pallet.SetStatus();

            return await palletRepository.UpdateAsync(pallet);
        }
    }
}
