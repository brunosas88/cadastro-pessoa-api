﻿// <auto-generated />
using System;
using CadastroPessoa.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CadastroPessoa.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230311183836_create-database")]
    partial class createdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EstaAtivo")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.PessoaFisica", b =>
                {
                    b.HasBaseType("CadastroPessoa.API.Domain.Models.Pessoa");

                    b.Property<int>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("integer");

                    b.ToTable("PessoasFisicas");
                });

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.PessoaJuridica", b =>
                {
                    b.HasBaseType("CadastroPessoa.API.Domain.Models.Pessoa");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.ToTable("PessoasJuridicas");
                });

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.Endereco", b =>
                {
                    b.HasOne("CadastroPessoa.API.Domain.Models.Pessoa", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("CadastroPessoa.API.Domain.Models.Endereco", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.PessoaFisica", b =>
                {
                    b.HasOne("CadastroPessoa.API.Domain.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("CadastroPessoa.API.Domain.Models.PessoaFisica", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.PessoaJuridica", b =>
                {
                    b.HasOne("CadastroPessoa.API.Domain.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("CadastroPessoa.API.Domain.Models.PessoaJuridica", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CadastroPessoa.API.Domain.Models.Pessoa", b =>
                {
                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
