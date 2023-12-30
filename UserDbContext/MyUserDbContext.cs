using Microsoft.EntityFrameworkCore;
using MySqlSampleConnection.Model;
namespace MySqlSampleConnection.UserDbContext
{
    public class MyUserDbContext:DbContext
    {

        public MyUserDbContext(DbContextOptions options): base(options)
            {
           
        }

        public DbSet<User> user { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseMySql(@"server=127.0.0.1;database=mycloud;User=root;Password=ntpc");


        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                //.HasName("PK_dept");


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName);
                //.HasName("PK_dept");


            });



        }








    }
}
