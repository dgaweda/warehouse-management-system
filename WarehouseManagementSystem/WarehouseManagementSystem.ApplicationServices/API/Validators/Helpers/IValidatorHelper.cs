using DataAccess.Entities.EntityBases;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators.Helpers
{
    public interface IValidatorHelper
    {
        bool CheckIfExist<TEntity>(int? id) where TEntity : class, IEntityBase;
        bool CheckIfExist<TEntity>(int id) where TEntity : class, IEntityBase;
        bool CheckIfLocationNameIsNotTaken(string name);
        int GetLocationMaxAmount(int id);
        bool CheckIfProductIsOnPalletForUnfolding(int id);
        bool CheckIfPalletForUnfoldingExist(int palletId);
        bool CheckIfProductBarcodeIsUnique(string barcode);
        bool CheckIfPalletBarcodeIsUnique(string barcode);
        bool CheckIfRoleNameIsUnique(string name);
        bool CheckIfEmployeeIsNotHired(int employeeId);
        bool CheckIfDeliveryExist(string name);
        bool CheckIfDepartureNameIsUnique(string name);
        bool CheckIfDepartureNameExist(string name);
        bool CheckEmailFormat(string email);
        bool CheckIfUserNameIsUnique(string username);
        bool CheckLocationCurrentAmount(int id);
    }
}