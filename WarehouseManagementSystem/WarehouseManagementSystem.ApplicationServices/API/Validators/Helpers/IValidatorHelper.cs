using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators
{
    public interface IValidatorHelper<TEntity>
    {
        bool CheckIfExist(int? id);
        bool CheckIfExist(int id);
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
    }
}