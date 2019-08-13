/* using System.Reflection;
using Projekt.Interface;
using Projekt.Models;
using Projekt.Models.Interface;

namespace Projekt.Extensions
{
    public class SoftDeleteSetupExtension
    {
        public static void SoftDeleteSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            SetupQueryFilter<Client>(modelBuilder);
            SetupQueryFilter<Phone>(modelBuilder);
            SetupQueryFilter<Operator>(modelBuilder);
            SetupQueryFilter<PhoneOperator>(modelBuilder);

            SetupQueryFilter<Bill>(modelBuilder);
            SetupQueryFilter<Location>(modelBuilder);
            SetupQueryFilter<Country>(modelBuilder);
            
        }

        private static void SetupQueryFilter<TEntity>(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
            where TEntity : class
        {
            if (typeof(ISoftDeletable).GetTypeInfo().IsAssignableFrom(typeof(TEntity).Ge‌​tTypeInfo()))
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(temp => !((ISoftDeletable)temp).IsDeleted);
            }
        }
    }
} */