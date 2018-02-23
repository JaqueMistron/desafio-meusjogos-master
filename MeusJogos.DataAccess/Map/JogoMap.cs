using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.DataAccess.Map
{
    class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {

            ToTable("jogo");

            HasKey(x => x.IdJogo);

            HasRequired(x => x.Usuario)
                .WithMany(x => x.ListaJogos)
                .HasForeignKey(x => x.IdUsuario);

            Property(x => x.Titulo).HasMaxLength(80).IsRequired();
            Property(x => x.Versao).HasMaxLength(20).IsOptional();
            Property(x => x.DataAquisicao).IsOptional();
        }
    }
}
