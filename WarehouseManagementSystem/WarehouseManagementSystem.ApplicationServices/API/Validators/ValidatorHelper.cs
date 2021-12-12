using DataAccess;
using DataAccess.Entities;
using DataAccess.Entities.EntityBases;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WarehouseManagementSystem.ApplicationServices.API.Validators
{
    public class ValidatorHelper : IValidatorHelper
    {
        private readonly WMSDatabaseContext _context;

        public ValidatorHelper(WMSDatabaseContext context)
        {
            _context = context;
        }

        public bool CheckIfExist<TEntity>(int id) where TEntity : EntityBase
        {
            var entity = _context.Set<TEntity>();
            return entity.Any(x => x.Id == id);
        }

        /// <summary>
        /// Sprawdza czy dany produkt istnieje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfProductExists(int? id)
        {
            return _context.Products.Any(x => x.Id == id);
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
        /// <returns></returns>
        public bool CheckIfPalletForUnfoldingExist(int palletId)
        {
            return _context.ProductPalletLines.Any(x => x.PalletId == palletId);
        }
    }
}
