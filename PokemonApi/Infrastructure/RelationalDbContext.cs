using System.Drawing.Printing;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure.Entities;

//ENTIDAD CREADA 
namespace PokemonApi.Infrastructure
{
    public class RelationalDbContext : DbContext
    {

        public  DbSet<PokemonEntity> Pokemons { get; set; } //DbSet es una coleccion de entidades que se mapean a una tabla en la base de datos
//Constructor  - pasar parametros de conexion al padre que es DbContext     
        public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonEntity>(entity=>{

                entity.HasKey(s=>s.Id); //Llave primaria
                entity.Property(s=>s.Name).IsRequired().HasMaxLength(100); //Nombre es requerido
                entity.Property(s=>s.Type).IsRequired().HasMaxLength(50); //Tipo es requerido
                entity.Property(s=>s.Level).IsRequired(); //Nivel es requerido
                entity.Property(s=>s.attack).IsRequired(); //Ataque es requerido
                entity.Property(s=>s.Defense).IsRequired(); //Defensa es requerido
                entity.Property(s=>s.Speed).IsRequired(); //Velocidad es requerido
            }); 

         }

    }
   
}