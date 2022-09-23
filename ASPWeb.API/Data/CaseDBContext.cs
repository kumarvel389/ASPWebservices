using ASPWeb.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPWeb.API.Data
{
    public class CaseDBContext:DbContext
    {

        public CaseDBContext(DbContextOptions<CaseDBContext> options): base(options)
        {

        }

// create tablet in database
        public DbSet<Case> Cases { get; set; }
    }
}
