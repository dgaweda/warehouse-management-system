using System;
using DataAccess.Entities.EntityBase;
using DataAccess.Enums;

namespace WarehouseManagementSystem.ApplicationServices.API.Validation.Validators
{
    public interface IValidatorHelper
    {
        bool Exist<TEntity>(Guid? id) where TEntity : EntityBase;
        bool Exist<TEntity>(Guid id) where TEntity : EntityBase;
        bool IsLocationWithThatNameExits(string name);
        int GetLocationMaxAmount(Guid id);
        bool IsProductOnPalletForUnfolding(Guid id);
        bool IsPalletForUnfoldingExist(Guid palletId);
        bool IsProductBarcodeUnique(string barcode);
        bool IsPalletBarcodeIsUnique(string barcode);
        bool IsRoleNameUnique(string name);
        bool IsHiredEmployee(Guid employeeId);
        bool IsDeliveryExist(string name);
        bool IsDepartureNameIsUnique(string name);
        bool IsDepartureNameExist(string name);
        bool IsUsernameExist(string username);
        bool IsLocationStillHaveProducts(Guid id);
        bool IsOrderBarcodeUnique(string barcode);
        bool IsPalletIdExistsInProductPalletLine(Guid palletId);
        bool IsInvoiceNumberNotExist(string invoiceNumber);
        bool IsLocationWithThatTypeExist(LocationType locationType);
    }
}