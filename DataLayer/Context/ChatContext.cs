using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options):base(options)
        {
            
        }

        #region Entities

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var cascades = modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetForeignKeys())
            //    .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //foreach (var fk in cascades)
            //{
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.Entity<Chat>()
                .HasOne(b => b.User)
                .WithMany(b => b.Chats)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserGroup>()
                .HasOne(b => b.User)
                .WithMany(b => b.UserGroups)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
