using AutomacaoAgendamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomacaoAgendamentos.Infrastructure.DataContext;

public class ServicoETC : IEntityTypeConfiguration<ServicoEntity>
{
    public void Configure(EntityTypeBuilder<ServicoEntity> builder)
    {
        builder.ToTable("SERVICOS");
        
        builder.HasKey(x => x.IdServico);
        
        builder.Property(x => x.IdServico)
            .HasColumnName("ID_SERVICO")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Descricao)
            .HasColumnName("DESCRICAO")
            .IsRequired()
            .HasMaxLength(60)
            .IsUnicode(false);

        builder.Property(x => x.Valor)
            .HasColumnName("VALOR")
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Duracao)
            .HasColumnName("DURACAO")
            .IsRequired()
            .HasColumnType("time");

        builder.Property(x => x.IdProfissional)
            .HasColumnName("ID_PROFISSIONAL")
            .IsRequired();

        builder.Property(x => x.IdTipoServico)
            .HasColumnName("ID_TIPO_SERVICO")
            .IsRequired();

        builder.Property(x => x.UsuarioAtualizacao)
            .HasColumnName("USUARIO_ATUALIZACAO")
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DATA_ATUALIZACAO")
            .HasColumnType("datetime");
    }
}