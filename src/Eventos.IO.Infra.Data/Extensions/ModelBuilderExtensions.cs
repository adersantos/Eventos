using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infra.Data.Extensions
{
    public class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}