using AutomacaoAgendamentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomacaoAgendamentos.Infrastructure.DataContext;

public class AgendamentoETC : IEntityTypeConfiguration<AgendamentoEntity>
{
    public void Configure(EntityTypeBuilder<AgendamentoEntity> builder)
    {
        builder.ToTable("AGENDAMENTOS");
        builder.HasKey(x => x.IdAgendamento);

        builder.Property(x => x.IdAgendamento).HasColumnName("ID_AGENDAMENTO").IsRequired();
        builder.Property(x => x.IdProfissional).HasColumnName("ID_PROFISSIONAL").IsRequired();
        builder.Property(x => x.IdServico).HasColumnName("ID_SERVICO").IsRequired();
        builder.Property(x => x.IdCliente).HasColumnName("ID_CLIENTE").IsRequired();
        builder.Property(x => x.NomeCliente).HasColumnName("NOME_CLIENTE").HasMaxLength(60).IsRequired();
        builder.Property(x => x.TelefoneCliente).HasColumnName("TELEFONE_CLIENTE").HasMaxLength(20).IsRequired();
        builder.Property(x => x.Data).HasColumnName("DATA").HasColumnType("date").IsRequired();
        builder.Property(x => x.HoraInicio).HasColumnName("HORA_INICIO").HasColumnType("time").IsRequired();
        builder.Property(x => x.HoraFim).HasColumnName("HORA_FIM").HasColumnType("time").IsRequired();
        builder.Property(x => x.IdSituacao).HasColumnName("ID_SITUACAO").IsRequired();
        builder.Property(x => x.UsuarioAtualizacao).HasColumnName("USUARIO_ATUALIZACAO").HasMaxLength(20);
        builder.Property(x => x.DataAtualizacao).HasColumnName("DATA_ATUALIZACAO").HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
    }
}