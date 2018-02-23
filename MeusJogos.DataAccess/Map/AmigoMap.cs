using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.DataAccess.Map
{
    public class AmigoMap : EntityTypeConfiguration<Amigo>
    {
        public AmigoMap()
        {

            ToTable("amigo");

            HasKey(x => x.IdAmigo);

            HasRequired(x => x.Usuario)
                .WithMany(x => x.ListaAmigos)
                .HasForeignKey(x => x.IdUsuario);

            Property(x => x.Nome).HasMaxLength(50).IsRequired();
            Property(x => x.Telefone).HasMaxLength(11).IsRequired();
        }
    }
}
