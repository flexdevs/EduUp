using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Categories;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Categories;

namespace EduUp.DataAccess.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
