using APIAdoPet.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TesteUnitariosAPIAdopet;

public class TestDatabaseFixture
{
<<<<<<< Updated upstream
    private const string ConnectionString = "server=localhost;port=3306;database=adopet_test;user=root;password=root;";
=======
    private const string ConnectionString = "server=localhost;port=3306;database=adopet;user=root;password=1234;";
>>>>>>> Stashed changes
    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureCreated();
                }
                _databaseInitialized = true;
            }
        }
        
    }
    public APIAdopetContext CreateContext() => new APIAdopetContext(
            new DbContextOptionsBuilder<APIAdopetContext>()
                .UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))
                .Options);
        
}
