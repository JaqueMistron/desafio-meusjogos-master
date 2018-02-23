using MeusJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusJogos.DataAccess.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("usuario");

            HasKey(x => x.IdUsuario);

            Property(x => x.Nome).HasMaxLength(50).IsRequired();
            Property(x => x.Senha).HasMaxLength(20).IsRequired();
            Ignore(x => x.Valido);
        }
    }
}
