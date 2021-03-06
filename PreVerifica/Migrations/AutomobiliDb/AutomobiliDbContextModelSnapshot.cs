// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PreVerifica.Data;

namespace PreVerifica.Migrations.AutomobiliDb
{
    [DbContext(typeof(AutomobiliDbContext))]
    partial class AutomobiliDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("PreVerifica.Models.Automobile", b =>
                {
                    b.Property<string>("PkId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeModello")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<int>("cavalli")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("data_di_produzione")
                        .HasColumnType("TEXT");

                    b.Property<string>("fkUserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PkId");

                    b.ToTable("Automobili");
                });
#pragma warning restore 612, 618
        }
    }
}
