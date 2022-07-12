using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Extensions
{
    public static class InvoiceExtension
    {
        public static void SetInvoiceNumber(this Invoice invoice, List<Invoice> invoices)
        {
            var lp = 1;
            invoices.ForEach(inv =>
            {
                if (inv.CreationDate.Date ==  invoice.CreationDate.Date && inv.Provider ==  invoice.Provider)
                    lp++;
            });
            
             invoice.InvoiceNumber = $"FV/{lp}/{ invoice.Provider}/{  invoice.CreationDate.Day}/{ invoice.CreationDate.Month}/{ invoice.CreationDate.Year}"; ;
        }

        public static List<Invoice> FilterByInvoiceNumber(this List<Invoice> invoices, string invoiceNumber)
        {
            if (string.IsNullOrEmpty(invoiceNumber))
                return invoices;

            return invoices.Where(invoice => invoice.InvoiceNumber.Contains(invoiceNumber.ToUpper())).ToList();
        }
    }
}