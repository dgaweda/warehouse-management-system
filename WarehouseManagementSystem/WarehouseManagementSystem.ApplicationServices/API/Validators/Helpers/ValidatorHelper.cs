using System;
using DataAccess;
using DataAccess.Entities.EntityBases;
using System.Linq;
using System.Net.Mail;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators
{
    public class ValidatorHelper : IValidatorHelper
    {
        private readonly WMSDatabaseContext _context;

        public ValidatorHelper(WMSDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Sprawdza czy istnieje rekord o podanym ID
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfExist<TEntity>(int? id)
            where TEntity : class, IEntityBase
        {
            return (id != null && id != 0) && _context.Set<TEntity>().Any(x => x.Id == id);
        }

        /// <summary>
        /// Sprawdza czy istnieje rekord o podanym ID
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfExist<TEntity>(int id) 
            where TEntity : class, IEntityBase
        {
            return id != 0 && _context.Set<TEntity>().Any(x => x.Id == id);
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

        /// <summary>
        /// Sprawdza czy nazwa użytkownika jest unikalna
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckIfUserNameIsUnique(string username)
        {
            return !_context.Users.Any(x => x.UserName == username);
        }

        /// <summary>
        /// Sprawdza czy na lokalizacji są jakieś produkty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckLocationCurrentAmount(int id)
        {
            var location = _context.Locations.SingleOrDefault(x => x.Id == id);
            return location.CurrentAmount < 0 || location.CurrentAmount > location.MaxAmount;
        }
    }
}
