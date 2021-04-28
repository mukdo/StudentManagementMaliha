using System.Threading.Tasks;

namespace StudentManagementTest.Data
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}
