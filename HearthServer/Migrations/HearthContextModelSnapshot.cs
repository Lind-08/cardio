﻿// <auto-generated />
using System;
using HearthServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HearthServer.Migrations
{
    [DbContext(typeof(HearthContext))]
    partial class HearthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("HearthServer.Models.Measurement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MillisDelta")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("SessionId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("HearthServer.Models.RegisteredDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Serial")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RegisteredDevices");
                });

            modelBuilder.Entity("HearthServer.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("HearthServer.Models.Measurement", b =>
                {
                    b.HasOne("HearthServer.Models.Session", "Session")
                        .WithMany("Measurements")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HearthServer.Models.Session", b =>
                {
                    b.HasOne("HearthServer.Models.RegisteredDevice", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");
                });
#pragma warning restore 612, 618
        }
    }
}