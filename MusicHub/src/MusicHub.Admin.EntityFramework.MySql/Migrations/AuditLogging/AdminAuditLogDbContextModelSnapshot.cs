﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicHub.Admin.EntityFramework.Shared.DbContexts;

#nullable disable

namespace MusicHub.Admin.EntityFramework.MySql.Migrations.AuditLogging
{
    [DbContext(typeof(AdminAuditLogDbContext))]
    partial class AdminAuditLogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Skoruba.AuditLogging.EntityFramework.Entities.AuditLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Action")
                        .HasColumnType("longtext");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<string>("Event")
                        .HasColumnType("longtext");

                    b.Property<string>("Source")
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectAdditionalData")
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectIdentifier")
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectName")
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectType")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AuditLog");
                });
#pragma warning restore 612, 618
        }
    }
}