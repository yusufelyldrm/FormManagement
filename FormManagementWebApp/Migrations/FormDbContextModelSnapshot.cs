﻿// <auto-generated />
using System;
using FormManagementWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormManagementWebApp.Migrations
{
    [DbContext(typeof(FormDbContext))]
    partial class FormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormManagementWebApp.Models.Domain.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<Guid?>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Required")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("FormManagementWebApp.Models.Domain.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("FormManagementWebApp.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FormManagementWebApp.Models.Domain.Field", b =>
                {
                    b.HasOne("FormManagementWebApp.Models.Domain.Form", null)
                        .WithMany("Fields")
                        .HasForeignKey("FormId");
                });

            modelBuilder.Entity("FormManagementWebApp.Models.Domain.Form", b =>
                {
                    b.HasOne("FormManagementWebApp.Models.Domain.User", null)
                        .WithMany("Forms")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FormManagementWebApp.Models.Domain.Form", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("FormManagementWebApp.Models.Domain.User", b =>
                {
                    b.Navigation("Forms");
                });
#pragma warning restore 612, 618
        }
    }
}
