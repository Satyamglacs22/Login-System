using Microsoft.EntityFrameworkCore;

namespace LoginformAspCore.Models
{
    public class UserDBContext :DbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserTable> Users { get; set; }

       
    }
}
