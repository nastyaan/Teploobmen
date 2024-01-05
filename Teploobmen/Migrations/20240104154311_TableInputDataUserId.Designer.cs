﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teploobmen.Data;

#nullable disable

namespace Teploobmen.Migrations
{
    [DbContext(typeof(MyApplicationContext))]
    [Migration("20240104154311_TableInputDataUserId")]
    partial class TableInputDataUserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Teploobmen.Data.InData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cg")
                        .HasColumnType("REAL");

                    b.Property<double>("Cm")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("TEXT");

                    b.Property<double>("Gm")
                        .HasColumnType("REAL");

                    b.Property<double>("H0")
                        .HasColumnType("REAL");

                    b.Property<double>("T_")
                        .HasColumnType("REAL");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("av")
                        .HasColumnType("REAL");

                    b.Property<double>("r")
                        .HasColumnType("REAL");

                    b.Property<double>("t0_")
                        .HasColumnType("REAL");

                    b.Property<double>("wg")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("inDatas");
                });

            modelBuilder.Entity("Teploobmen.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
