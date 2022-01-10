﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}