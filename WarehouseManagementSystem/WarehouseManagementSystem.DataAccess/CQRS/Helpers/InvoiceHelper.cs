using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.CQRS.Helpers
{
    public static class InvoiceHelper
    {
        public static void SetInvoiceNumber(this Invoice Parameter, List<Invoice> invoices)
        {
            var lp = 1;
            invoices.ForEach(invoice =>
            {
                if (invoice.CreationDate.Date == Parameter.CreationDate.Date && invoice.Provider == Parameter.Provider)
                    lp++;
            });
            
            Parameter.InvoiceNumber = $"FV/{lp}/{Parameter.Provider}/{ Parameter.CreationDate.Day}/{Parameter.CreationDate.Month}/{Parameter.CreationDate.Year}"; ;
        }

        public static List<Invoice> FilterByInvoiceNumber(this List<Invoice> invoices, string InvoiceNumber)
        {
            if (string.IsNullOrEmpty(InvoiceNumber))
                return invoices;

            return invoices.Where(invoice => invoice.InvoiceNumber.Contains(InvoiceNumber.ToUpper())).ToList();
        }
    }
}
