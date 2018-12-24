using ELearning.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Persistence
{
    public class ELearningDbContextFactory : DesignTimeDbContextFactoryBase<ELearningDbContext>
    {
        protected override ELearningDbContext CreateNewInstance(DbContextOptions<ELearningDbContext> options)
        {
            return new ELearningDbContext(options);
        }
    }
}
