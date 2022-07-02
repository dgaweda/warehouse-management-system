using System;
using System.Linq;
using System.Net.Mail;
using DataAccess;
using DataAccess.Entities.EntityBases;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers
{
    public class ValidatorHelper : IValidatorHelper
    {
        private readonly WMSDatabaseContext _context;

        public ValidatorHelper(WMSDatabaseContext context)
        {
            _context = context;
        }
        
        public bool Exist<TEntity>(int? id)
            where TEntity : class, IEntityBase
        {
            return (id != null && id != 0) && _context.Set<TEntity>().Any(x => x.Id == id);
        }
        
        public bool Exist<TEntity>(int id) 
            where TEntity : class, IEntityBase
        {
            return id != 0 && _context.Set<TEntity>().Any(x => x.Id == id);
        }
        
        public bool IsLocationWithThatNameExits(string name)
        {
            return _context.Locations.Any(x => x.Name == name);
        }
        
        public int GetLocationMaxAmount(int id)
        {
            return _context.Locations.Where(y => y.Id == id).Select(x => x.MaxAmount).FirstOrDefault();
        }

        public bool IsProductOnPalletForUnfolding(int id)
        {
            return _context.ProductPalletLines.Any(x => x.ProductId == id);
        }

        public bool IsPalletForUnfoldingExist(int palletId)
        {
            return _context.ProductPalletLines.Any(x => x.PalletId == palletId);
        }
        
        public bool IsProductBarcodeUnique(string barcode)
        {
            return !_context.Products.Any(x => x.Barcode == barcode);
        }
        
        public bool IsPalletBarcodeIsUnique(string barcode)
        {
            return !_context.Pallets.Any(x => x.Barcode == barcode);
        }
        
        public bool IsRoleNameUnique(string name)
        {
            return !_context.Roles.Any(x => x.Name == name);
        }

        public bool IsHiredEmployee(int userId)
        {
            return !_context.Seniorities.Any(x => x.UserId == userId);
        }
        
        public bool IsDeliveryExist(string name)
        {
            return string.IsNullOrEmpty(name) || _context.Deliveries.Any(x => x.Name.Contains(name));
        }
        
        public bool IsDepartureNameIsUnique(string name)
        {
            return !_context.Departures.Any(x => x.Name == name);
        }

        public bool IsDepartureNameExist(string name)
        {
            return string.IsNullOrEmpty(name) || _context.Departures.Any(x => x.Name.Contains(name));
        }

        public bool IsUsernameExist(string username)
        {
            return !_context.Users.Any(x => x.UserName == username);
        }
        
        public bool IsLocationStillHaveProducts(int id)
        {
            var location = _context.Locations.SingleOrDefault(x => x.Id == id);
            return location?.CurrentAmount < 0 || location?.CurrentAmount > location?.MaxAmount;
        }

        public bool IsOrderBarcodeUnique(string barcode)
        {
            return !_context.Orders.Any(x => x.Barcode.Equals(barcode));
        }

        public bool IsPalletIdExistsInProductPalletLine(int palletId)
        {
            return _context.ProductPalletLines.Any((x) => x.PalletId == palletId);
        }

        public bool IsInvoiceNumberNotExist(string invoiceNumber)
        {
            return !_context.Invoices.Any(x => x.InvoiceNumber == invoiceNumber);
        }

        public bool IsLocationWithThatTypeExist(LocationType locationType)
        {
            return _context.Locations.Any(x => x.LocationType == locationType);
        }
    }
}
