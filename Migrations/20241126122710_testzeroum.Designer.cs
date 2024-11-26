﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeadRosen.Data;

#nullable disable

namespace NeadRosen.Migrations
{
    [DbContext(typeof(NeadTestContext))]
    [Migration("20241126122710_testzeroum")]
    partial class testzeroum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NeadRosen.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("NeadRosen.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("NeadRosen.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PeriodoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeriodoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("NeadRosen.Models.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Sala")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Periodos");
                });

            modelBuilder.Entity("NeadRosen.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("NeadRosen.Models.Secao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrabalhoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrabalhoId");

                    b.ToTable("Secoes");
                });

            modelBuilder.Entity("NeadRosen.Models.Trabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Trabalhos");
                });

            modelBuilder.Entity("NeadRosen.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("NeadRosen.Models.Disciplina", b =>
                {
                    b.HasOne("NeadRosen.Models.Periodo", null)
                        .WithMany("Disciplinas")
                        .HasForeignKey("PeriodoId");

                    b.HasOne("NeadRosen.Models.Professor", null)
                        .WithMany("DisciplinasRevisadas")
                        .HasForeignKey("ProfessorId");
                });

            modelBuilder.Entity("NeadRosen.Models.Periodo", b =>
                {
                    b.HasOne("NeadRosen.Models.Aluno", null)
                        .WithMany("PeriodosRealizados")
                        .HasForeignKey("AlunoId");

                    b.HasOne("NeadRosen.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("NeadRosen.Models.Secao", b =>
                {
                    b.HasOne("NeadRosen.Models.Trabalho", null)
                        .WithMany("Secoes")
                        .HasForeignKey("TrabalhoId");
                });

            modelBuilder.Entity("NeadRosen.Models.Trabalho", b =>
                {
                    b.HasOne("NeadRosen.Models.Disciplina", "Disciplina")
                        .WithMany("Trabalhos")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("NeadRosen.Models.Usuario", b =>
                {
                    b.HasOne("NeadRosen.Models.Disciplina", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("DisciplinaId");
                });

            modelBuilder.Entity("NeadRosen.Models.Aluno", b =>
                {
                    b.Navigation("PeriodosRealizados");
                });

            modelBuilder.Entity("NeadRosen.Models.Disciplina", b =>
                {
                    b.Navigation("Trabalhos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("NeadRosen.Models.Periodo", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("NeadRosen.Models.Professor", b =>
                {
                    b.Navigation("DisciplinasRevisadas");
                });

            modelBuilder.Entity("NeadRosen.Models.Trabalho", b =>
                {
                    b.Navigation("Secoes");
                });
#pragma warning restore 612, 618
        }
    }
}
