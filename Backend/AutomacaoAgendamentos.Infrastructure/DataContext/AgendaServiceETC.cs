using AutomacaoAgendamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomacaoAgendamentos.Infrastructure.DataContext;

public class AgendaServiceETC : IEntityTypeConfiguration<AgendaEntity>
{
    public void Configure(EntityTypeBuilder<AgendaEntity> builder)
    {
        builder.ToTable("AGENDA");
        builder.HasKey(x => x.IdAgenda);

        builder.Property(x => x.IdAgenda).HasColumnName("ID_AGENDA");
        builder.Property(x => x.IdProfissional).HasColumnName("ID_PROFISSIONAL").IsRequired();
        builder.Property(x => x.DiaSemana).HasColumnName("DIAS_SEMANA").IsRequired();
        builder.Property(x => x.HoraInicio).HasColumnName("HORA_INICIO").HasColumnType("time").IsRequired();
        builder.Property(x => x.HoraFim).HasColumnName("HORA_FIM").HasColumnType("time").IsRequired();
        builder.Property(x => x.UsuarioAtualizacao).HasColumnName("USUARIO_ATUALIZACAO").HasMaxLength(20);
        builder.Property(x => x.DataAtualizacao).HasColumnName("DATA_ATUALIZACAO").HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");;
    }
}