﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicHub.Admin.EntityFramework.Shared.DbContexts;

#nullable disable

namespace MusicHub.Admin.EntityFramework.MySql.Migrations.Logging
{
    [DbContext(typeof(AdminLogDbContext))]
    [Migration("20220515160712_DBInit")]
    partial class DBInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Skoruba.Duende.IdentityServer.Admin.EntityFramework.Entities.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Exception")
                        .HasColumnType("longtext");

                    b.Property<string>("Level")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("LogEvent")
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("longtext");

                    b.Property<string>("Properties")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Log", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}