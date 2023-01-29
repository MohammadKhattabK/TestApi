﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApi.Data;

#nullable disable

namespace TestApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TestApi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TestApi.Models.Custom", b =>
                {
                    b.Property<int>("customId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customId"), 1L, 1);

                    b.Property<int>("customGroupId")
                        .HasColumnType("int");

                    b.Property<string>("customKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customId");

                    b.HasIndex("customGroupId");

                    b.ToTable("Customs");
                });

            modelBuilder.Entity("TestApi.Models.CustomGroup", b =>
                {
                    b.Property<int>("customGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customGroupId"), 1L, 1);

                    b.Property<string>("customGroupTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("customGroupId");

                    b.HasIndex("productId");

                    b.ToTable("CustomGroups");
                });

            modelBuilder.Entity("TestApi.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productId"), 1L, 1);

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("duration")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("productId");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TestApi.Models.Custom", b =>
                {
                    b.HasOne("TestApi.Models.CustomGroup", "CustomGroup")
                        .WithMany("customDescription")
                        .HasForeignKey("customGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomGroup");
                });

            modelBuilder.Entity("TestApi.Models.CustomGroup", b =>
                {
                    b.HasOne("TestApi.Models.Product", "Product")
                        .WithMany("CustomGroup")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TestApi.Models.Product", b =>
                {
                    b.HasOne("TestApi.Models.Category", "Category")
                        .WithMany("CategoryDescription")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TestApi.Models.Category", b =>
                {
                    b.Navigation("CategoryDescription");
                });

            modelBuilder.Entity("TestApi.Models.CustomGroup", b =>
                {
                    b.Navigation("customDescription");
                });

            modelBuilder.Entity("TestApi.Models.Product", b =>
                {
                    b.Navigation("CustomGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
