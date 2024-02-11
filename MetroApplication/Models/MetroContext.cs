using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MetroApplication.Models
{
    public class MetroContext:DbContext
    {
        public MetroContext() : base("DefaultConnection")
        {
        
        }   
        public DbSet<Станции> Stations { get; set; }
        public DbSet<Терминалы> Terminals { get; set; }
        public DbSet<Операторы> Operators { get; set; }
        public DbSet<Работники> Workers { get; set; }
        public DbSet<Роли> Roles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
        }
    }
    

}
