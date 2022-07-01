using DataAccess.Entities.EntityBases;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators
{
    public interface IValidatorHelper
    {
        bool Exist<TEntity>(int? id) where TEntity : class, IEntityBase;
        bool Exist<TEntity>(int id) where TEntity : class, IEntityBase;
        bool IsLocationNameIsTaken(string name);
        int GetLocationMaxAmount(int id);
        bool IsProductOnPalletForUnfolding(int id);
        bool IsPalletForUnfoldingExist(int palletId);
        bool IsProductBarcodeUnique(string barcode);
        bool IsPalletBarcodeIsUnique(string barcode);
        bool IsRoleNameUnique(string name);
        bool IsHiredEmployee(int employeeId);
        bool IsDeliveryExist(string name);
        bool IsDepartureNameIsUnique(string name);
        bool IsDepartureNameExist(string name);
        bool IsUsernameExist(string username);
        bool IsLocationStillHaveProducts(int id);
        bool IsOrderBarcodeUnique(string barcode);
        bool IsPalletIdExistsInProductPalletLine(int palletId);
        bool IsInvoiceNumberNotExist(string invoiceNumber);
    }
}