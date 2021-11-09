using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Commands.InvoiceCommands
{
    public class SetInvoiceNumber
    {
        public void Set(List<Invoice> invoices, Invoice Parameter)
        {
            var id = CountRepetitionOfDateAndProvider(invoices, Parameter);

            Parameter.InvoiceNumber = $"INV/{id}/{Parameter.Provider}/{ Parameter.CreationDate.Day}/{Parameter.CreationDate.Month}/{Parameter.CreationDate.Year}";
        }

        public int CountRepetitionOfDateAndProvider(List<Invoice> invoices, Invoice Parameter)
        {
            var id = 1;
            invoices.ForEach(invoice =>
            {
                if (invoice.CreationDate.Date == Parameter.CreationDate.Date && invoice.Provider == Parameter.Provider)
                    id++;
            });
            return id;
        }
    }
}
