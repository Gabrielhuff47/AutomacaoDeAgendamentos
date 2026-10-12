using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomacaoAgendamentos.Infrastructure.DataContext;

public class ProfissionalETC : IEntityTypeConfiguration<ProfissionalEntity>
{
    public void Configure(EntityTypeBuilder<ProfissionalEntity> builder)
    {
        builder.ToTable("PROFISSIONAIS");

        builder.HasKey(p => p.IdProfissional);

        builder.Property(p => p.IdProfissional)
            .HasColumnName("ID_PROFISSIONAL")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Cpf).IsRequired().HasMaxLength(11);
        builder.Property(p => p.Usuario).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Senha).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Telefone).IsRequired().HasMaxLength(20);
        builder.Property(p => p.IdEstabelecimento)
            .HasColumnName("ID_ESTABELECIMENTO").IsRequired();
        builder.Property(p => p.IsAdmin)
            .HasColumnName("IS_ADMIN").IsRequired();
        builder.Property(p => p.UsuarioAtualizacao)
            .HasColumnName("USUARIO_ATUALIZACAO").HasMaxLength(20).IsUnicode(false);
        builder.Property(p => p.DataAtualizacao)
            .HasColumnName("DATA_ATUALIZACAO").HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");

        builder.HasIndex(p => p.Cpf).IsUnique();
        builder.HasIndex(p => p.Usuario).IsUnique();
    }
}