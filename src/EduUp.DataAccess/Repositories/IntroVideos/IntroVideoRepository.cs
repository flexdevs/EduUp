using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.IntroVideos;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.IntroVideos;

namespace EduUp.DataAccess.Repositories.IntroVideos
{
    public class IntroVideoRepository : GenericRepository<IntroVideo>, IIntroVideoRepository
    {
        public IntroVideoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
