using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public class CategoryDal : ICategoryDal
    {
        private readonly Context context;

        public CategoryDal(Context context)
        {
            this.context = context;
        }
        public async Task<Category> GetCategoryById(int Id)
        {
            try
            {
                return await context.Categories.FirstAsync(c => c.Id == Id);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<Category> GetCategoryByName(string name)
        {
            try
            {
                return await context.Categories.FirstAsync(c => c.Name == name);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Category> ChangeName(Category c)
        {
            try
            {
                context.Categories.Update(c);
                await context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Category> DeleteCategory(int IdCategory)
        {
            try
            {
                Category category = await context.Categories.FirstAsync(x => x.Id == IdCategory);
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                return await context.Categories.Select(x => x).ToListAsync();
            }
            catch (Exception ex)
            {
                throw /*Exception ex*/;

            }
        }
    }
}
