using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.InvoiceValidators
{
    public interface IValidationForInvoice
    {
        void InvoiceValidation();
        bool CheckIfDeliveryExists(int id);
        bool CheckIfInvoiceExists(int id);
    }
}
