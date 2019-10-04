﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modelo.Infra.Data.Context;

namespace Modelo.Infra.Data.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    partial class SQLServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelo.Domain.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MarcaId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("Updated")
                        .HasColumnName("Updated");

                    b.HasKey("Id");

                    b.ToTable("tbMarca");
                });

            modelBuilder.Entity("Modelo.Domain.Entities.Patrimonio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao");

                    b.Property<int>("MarcaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(255);

                    b.Property<int>("NumeroTombo")
                        .HasColumnName("NumeroTombo");

                    b.Property<DateTime?>("Updated")
                        .HasColumnName("Updated");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("tbPatrimonio");
                });

            modelBuilder.Entity("Modelo.Domain.Entities.Patrimonio", b =>
                {
                    b.HasOne("Modelo.Domain.Entities.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .HasConstraintName("FK_Patrimonio_Marca")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
