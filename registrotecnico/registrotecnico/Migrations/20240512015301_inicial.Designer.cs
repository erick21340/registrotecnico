﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using registrotecnico.DAL;

#nullable disable

namespace registrotecnico.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240512015301_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("registrotecnico.Models.tecnicos", b =>
                {
                    b.Property<int>("TecnicosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("sueldohoras")
                        .HasColumnType("REAL");

                    b.HasKey("TecnicosId");

                    b.ToTable("tecnicos");
                });
#pragma warning restore 612, 618
        }
    }
}
