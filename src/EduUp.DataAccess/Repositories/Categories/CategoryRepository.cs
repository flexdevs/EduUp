using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Categories;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.DataAccess.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
