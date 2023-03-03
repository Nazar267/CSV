using Microsoft.EntityFrameworkCore;

namespace WEP_API_TEST_CSV.models
{
    public class CsvDbContext:DbContext
    {
        public CsvDbContext(DbContextOptions<CsvDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CSVDoc> CsvDocs { get; set; }
    }
}
