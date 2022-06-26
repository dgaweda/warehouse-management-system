using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;

namespace DataAccess.CQRS.Extensions
{
    public static class InvoiceExtension
    {
        public static void SetInvoiceNumber(this Invoice @invoice, List<Invoice> invoices)
        {
            var lp = 1;
            invoices.ForEach(invoice =>
            {
                if (invoice.CreationDate.Date ==  @invoice.CreationDate.Date && invoice.Provider ==  @invoice.Provider)
                    lp++;
            });
            
             @invoice.InvoiceNumber = $"FV/{lp}/{ @invoice.Provider}/{  @invoice.CreationDate.Day}/{ @invoice.CreationDate.Month}/{ @invoice.CreationDate.Year}"; ;
        }

        public static List<Invoice> FilterByInvoiceNumber(this List<Invoice> invoices, string InvoiceNumber)
        {
            if (string.IsNullOrEmpty(InvoiceNumber))
                return invoices;

            return invoices.Where(invoice => invoice.InvoiceNumber.Contains(InvoiceNumber.ToUpper())).ToList();
        }
    }
}