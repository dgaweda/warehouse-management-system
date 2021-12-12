using DataAccess.Entities.EntityBases;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators
{
    public interface IValidatorHelper
    {
        bool CheckIfExist<TEntity>(int id) where TEntity : EntityBase;
        bool CheckIfProductExists(int? id);
        bool CheckIfLocationNameIsNotTaken(string name);
        int GetLocationMaxAmount(int id);
        bool CheckIfProductIsOnPalletForUnfolding(int id);
        bool CheckIfPalletForUnfoldingExist(int palletId);
    }
}