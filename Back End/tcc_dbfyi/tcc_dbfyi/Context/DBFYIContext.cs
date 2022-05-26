using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using tcc_dbfyi.Domains;

#nullable disable

namespace tcc_dbfyi.Context
{
    public partial class DBFYIContext : DbContext
    {
        public DBFYIContext()
        {
        }

        public DBFYIContext(DbContextOptions<DBFYIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Inscricao> Inscricaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =fyilearning2.database.windows.net; initial catalog = DBFYI; user Id = administrador; pwd = FYIlearningsolutions@5;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__categori__8A3D240CB5BEFC44");

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__curso__8551ED054B5DE1FC");

                entity.ToTable("curso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.CargaHoraria)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("cargaHoraria");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NomeCurso)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeCurso");

                entity.Property(e => e.VagasDisponiveis)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("vagasDisponiveis");

                entity.Property(e => e.VagasPreenchidas)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("vagasPreenchidas");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__curso__idCategor__2B3F6F97");
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao)
                    .HasName("PK__inscrica__CB2B18FE3355CA1E");

                entity.ToTable("inscricao");

                entity.Property(e => e.IdInscricao).HasColumnName("idInscricao");

                entity.Property(e => e.DataInscricao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataInscricao");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Inscricaos)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__inscricao__idTur__31EC6D26");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Inscricaos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__inscricao__idUsu__30F848ED");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFFA512ABD2");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__turma__AA06831071CF2BD9");

                entity.ToTable("turma");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.NomeTurma)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nomeTurma");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__turma__idCurso__2E1BDC42");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A666DF8A62");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(266)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("empresa");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
