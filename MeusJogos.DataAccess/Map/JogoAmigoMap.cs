using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.DataAccess.Map
{
    public class JogoAmigoMap : EntityTypeConfiguration<JogoAmigo>
    {
        public JogoAmigoMap()
        {
            ToTable("jogo_amigo");

            HasKey(x => new { x.IdJogoAmigo });

            HasRequired(x => x.Jogo)
                .WithMany(x => x.ListaJogosEmprestados)
                .HasForeignKey(x => x.IdJogo);

            HasRequired(x => x.Amigo)
                .WithMany(x => x.ListaJogosEmprestados)
                .HasForeignKey(x => x.IdAmigo)
                .WillCascadeOnDelete(true);

            HasRequired(x => x.Usuario)
                .WithMany(x => x.ListaJogosEmprestados)
                .HasForeignKey(x => x.IdUsuario)
                .WillCascadeOnDelete(true);

            Property(x => x.DataRetirada).IsRequired();
            Property(x => x.DataDevolucao).IsOptional();
        }
    }
}
