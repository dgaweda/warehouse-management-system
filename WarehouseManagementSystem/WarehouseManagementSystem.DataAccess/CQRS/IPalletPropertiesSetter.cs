using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.PalletCommands
{
    public interface IPalletPropertiesSetter
    {
        void SetPalletProperties(Pallet pallet, Pallet parameter);
        void SetPalletStatus(Pallet pallet);
    }
}
