using DataAccess.Entities;
using System.Threading.Tasks;
using DataAccess.CQRS.Command;
using DataAccess.CQRS.Command.Commands;
using DataAccess.Repository;
using DataAccess.Repository.PalletRepository;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public class AddPalletCommand : CommandBase<Pallet, Pallet, IPalletRepository>
    {
        public override async Task<Pallet> Execute(IPalletRepository palletRepository)
        {
            return await palletRepository.AddAsync(Parameter);
        }
    }
}
