﻿// <auto-generated />
using System;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(RoomMateDBContext))]
    [Migration("20240509153824_AddedNewEntity")]
    partial class AddedNewEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("DAL.Entities.House", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("House");
                });

            modelBuilder.Entity("DAL.Entities.HouseWork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HouseWork");
                });

            modelBuilder.Entity("DAL.Entities.Prize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Prize");
                });

            modelBuilder.Entity("DAL.Entities.Roomate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("RoomMate");
                });

            modelBuilder.Entity("DAL.Entities.Valutation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Star")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("WorkShiftId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WorkShiftId");

                    b.ToTable("Valutation");
                });

            modelBuilder.Entity("DAL.Entities.WorkShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("HouseWorkId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.HasIndex("HouseWorkId");

                    b.ToTable("WorkShift");
                });

            modelBuilder.Entity("DAL.Entities.Prize", b =>
                {
                    b.HasOne("DAL.Entities.House", "House")
                        .WithMany("Prizes")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("DAL.Entities.Roomate", b =>
                {
                    b.HasOne("DAL.Entities.House", "House")
                        .WithMany("Roomates")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("DAL.Entities.Valutation", b =>
                {
                    b.HasOne("DAL.Entities.WorkShift", "WorkShift")
                        .WithMany("valutations")
                        .HasForeignKey("WorkShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("DAL.Entities.WorkShift", b =>
                {
                    b.HasOne("DAL.Entities.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.HouseWork", "HouseWork")
                        .WithMany()
                        .HasForeignKey("HouseWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("HouseWork");
                });

            modelBuilder.Entity("DAL.Entities.House", b =>
                {
                    b.Navigation("Prizes");

                    b.Navigation("Roomates");
                });

            modelBuilder.Entity("DAL.Entities.WorkShift", b =>
                {
                    b.Navigation("valutations");
                });
#pragma warning restore 612, 618
        }
    }
}