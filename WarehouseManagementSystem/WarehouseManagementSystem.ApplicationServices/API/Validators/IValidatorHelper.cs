using DataAccess.Entities.EntityBases;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers
{
    public interface IValidatorHelper
    {
        bool IsExist<TEntity>(int? id) where TEntity : class, IEntityBase;
        bool IsExist<TEntity>(int id) where TEntity : class, IEntityBase;
        bool IsLocationNameIsTaken(string name);
        int GetLocationMaxAmount(int id);
        bool IsProductOnPalletForUnfolding(int id);
        bool IsPalletForUnfoldingExist(int palletId);
        bool IsProductBarcodeUnique(string barcode);
        bool IsPalletBarcodeIsUnique(string barcode);
        bool IsRoleNameIsUnique(string name);
        bool IsHiredEmployee(int employeeId);
        bool IsDeliveryExist(string name);
        bool IsDepartureNameIsUnique(string name);
        bool IsDepartureNameExist(string name);
        bool CheckEmailFormat(string email);
        bool IsUsernameIsUnique(string username);
        bool IsLocationStillHaveProducts(int id);
        bool IsUsernameExist(string username);
        bool IsOrderBarcodeIsUnique(string barcode);
        bool IsPalletIdExistsInProductPalletLine(int palletId);
    }
}