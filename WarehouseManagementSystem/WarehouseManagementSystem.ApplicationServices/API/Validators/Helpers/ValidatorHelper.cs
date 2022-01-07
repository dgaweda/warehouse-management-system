using System;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Entities.EntityBases;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Mail;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators
{
    public class ValidatorHelper<TEntity> : IValidatorHelper<TEntity> where TEntity : EntityBase
    {
        private readonly WMSDatabaseContext _context;
        private readonly DbSet<TEntity> entity;

        public ValidatorHelper(WMSDatabaseContext context)
        {
            _context = context;
            entity = _context.Set<TEntity>();
        }

        /// <summary>
        /// Sprawdza czy istnieje rekord o podanym ID
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfExist(int id)
        {
            return entity.Any(x => x.Id == id);
        }

        /// <summary>
        /// Sprawdza czy istnieje rekord o podanym ID
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfExist(int? id)
        {
            return id is null || entity.Any(x => x.Id == id);
        }

        /// <summary>
        /// Sprawdza czy nazwa lokalizacji nie jest zajęta
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckIfLocationNameIsNotTaken(string name)
        {
            return _context.Locations.Any(x => x.Name == name);
        }

        /// <summary>
        /// Pobiera maksymalną pojemność półki / lokalizacji
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int GetLocationMaxAmount(int Id)
        {
            return _context.Locations.Where(y => y.Id == Id).Select(x => x.MaxAmount).FirstOrDefault();
        }

        /// <summary>
        /// Sprawdza czy produkt jest na palecie do rozłożenia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfProductIsOnPalletForUnfolding(int id)
        {
            return _context.ProductPalletLines.Any(x => x.ProductId == id);
        }

        /// <summary>
        /// Sprawdza czy wskazana paleta do rozłożenia istnieje
        /// </summary>
        /// <param name="palletId"></param>
        /// <returns></returns>
        public bool CheckIfPalletForUnfoldingExist(int palletId)
        {
            return _context.ProductPalletLines.Any(x => x.PalletId == palletId);
        }

        /// <summary>
        /// Sprawdza czy kod kreskowy produktu jest unikalny
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public bool CheckIfProductBarcodeIsUnique(string barcode)
        {
            return !_context.Products.Any(x => x.Barcode == barcode);
        }

        /// <summary>
        /// Sprawdza czy kod kreskowy palety jest unikalny
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public bool CheckIfPalletBarcodeIsUnique(string barcode)
        {
            return !_context.Pallets.Any(x => x.Barcode == barcode);
        }

        /// <summary>
        /// Sprawdza czy w bazie nie istnieje rola o podanej nazwie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckIfRoleNameIsUnique(string name)
        {
            return !_context.Roles.Any(x => x.Name == name);
        }

        /// <summary>
        /// Sprawdza czy pracownik nie został już zatrudniony
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool CheckIfEmployeeIsNotHired(int userId)
        {
            return !_context.Seniorities.Any(x => x.UserId == userId);
        }

        /// <summary>
        /// Sprawdza czy podana dostawa istnieje
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckIfDeliveryExist(string name)
        {
            return string.IsNullOrEmpty(name) || _context.Deliveries.Any(x => x.Name.Contains(name));
        }

        /// <summary>
        /// Sprawdza czy nazwa wyjazdu jest unikalna
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckIfDepartureNameIsUnique(string name)
        {
            return !_context.Departures.Any(x => x.Name == name);
        }

        /// <summary>
        /// Sprawdza czy podana nazwa wyjazdu nie istnieje w bazie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckIfDepartureNameExist(string name)
        {
            return string.IsNullOrEmpty(name) || _context.Departures.Any(x => x.Name.Contains(name));
        }

        /// <summary>
        /// Sprawdza czy email jest poprawny
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmailFormat(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
