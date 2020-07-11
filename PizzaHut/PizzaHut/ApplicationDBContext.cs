namespace PizzaHut
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("name=ApplicationDBContext")
        {
        }

        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .HasMany(e => e.Toppings)
                .WithMany(e => e.Pizzas)
                .Map(m => m.ToTable("Composition").MapLeftKey("PizzaId").MapRightKey("ToppingId"));

            modelBuilder.Entity<Topping>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
