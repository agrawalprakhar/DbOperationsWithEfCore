using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            
        }
    }
}
