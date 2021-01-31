using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rentid.Entities;

namespace rentid.Context
{
    public class appDbContext:IdentityDbContext<appUser,appRole,string>
    {
        public appDbContext(DbContextOptions<appDbContext> option):base(option)
        {
            
        }
    }
}