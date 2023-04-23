using Backend.Contexts;
using Backend.Models.Dtos;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ProductRepository
    {

        #region Constructor
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        {

            var items = await _context.Products.ToListAsync();

            var products = new List<ProductResponse>();

            foreach (var item in items)
            {
                products.Add(item);
            }

                return products;
        }

        public async Task<ProductResponse> CreateAsync(ProductEntity entity)
        {

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<ProductResponse> GetByIdAsync(Guid id) 
        {
            var result = await _context.Products.FindAsync(id);
            return result!;
        }





        public async Task<IEnumerable<ProductResponse>> GetByTagAsync(string tag)
        {

            var products = await _context.Products.ToListAsync();

            var result = products.Where(x => x.Tag.ToString().ToLower() == tag.ToLower()).ToList();

            var listan = new List<ProductResponse>();

            foreach (var item in result)
            {
                listan.Add(item);
            }

            return listan;
        }
        



        















        //public async Task DeleteAsync(Guid id)
        //{

        //    _context.Products.Remove(entity);
        //    await _context.SaveChangesAsync();

        //}









    }
}
