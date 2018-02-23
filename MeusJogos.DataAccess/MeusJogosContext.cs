using System;
using System.Data.Entity;
using MeusJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using MeusJogos.DataAccess.Map;

namespace MeusJogos.DataAccess
{
    public class MeusJogosContext : DbContext
    {
        public MeusJogosContext() : base("MeusJogosBDConexao")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<JogoAmigo> JogosEmprestados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties()
                   .Where(p => p.Name == "Id" + p.ReflectedType.Name)
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(200));
            modelBuilder.Properties<DateTime>().Configure(p => p.HasColumnType("datetime"));

            modelBuilder.Configurations.Add(new AmigoMap());
            modelBuilder.Configurations.Add(new JogoMap());
            modelBuilder.Configurations.Add(new JogoAmigoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

        }
    }
}
