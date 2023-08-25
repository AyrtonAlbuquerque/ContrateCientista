using Api.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<DataContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}