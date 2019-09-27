using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RevInfotech.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RevInfotech.Context
{
    public class RevinfotechContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public RevinfotechContext(DbContextOptions<RevinfotechContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCodeCardEntity>()
                .HasKey(c => new { c.CodeId, c.AccountNo });
            modelBuilder.Entity<UserSecurityQuestionEntity>()
               .HasKey(c => new { c.QuestionId, c.AccountId });
            modelBuilder.Entity<GenericSetting>()
                .HasKey(c => new { c.SettingID, c.AdminAccountId, c.SettingName, c.SubSettingName });
            foreach (var property in modelBuilder.Model.GetEntityTypes()
   .SelectMany(t => t.GetProperties())
   .Where(p => p.ClrType == typeof(decimal)))
            {
                property.Relational().ColumnType = "decimal(18, 8)";
            }
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CityEntity> CityEntitys { get; set; }
        public DbSet<StateEntity> StateEntitys { get; set; }
        public DbSet<BlogEntity> BlogEntitys { get; set; }
        public DbSet<BlogDescription> BlogDescriptions { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<CategoryEntity> CategoryEntitys { get; set; }
        //public DbSet<User> Users { get; set; }

        public DbSet<UserCodeCardEntity> UserCodeCardEntity { get; set; }
        public DbSet<UserSecurityQuestionEntity> UserSecurityQuestion { get; set; }
        
    }
}
