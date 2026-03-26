using System;
using System.Collections.Generic;
using Api_WildOasis.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_WildOasis.Data;

public partial class WildOasisContext : DbContext
{
    public WildOasisContext()
    {
    }

    public WildOasisContext(DbContextOptions<WildOasisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Cabin> Cabins { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.CabinId).HasColumnName("cabinId");
            entity.Property(e => e.CabinPrice).HasColumnName("cabinPrice");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.ExtrasPrice).HasColumnName("extrasPrice");
            entity.Property(e => e.HasBreakfast).HasColumnName("hasBreakfast");
            entity.Property(e => e.IsPaid).HasColumnName("isPaid");
            entity.Property(e => e.NumGuests).HasColumnName("numGuests");
            entity.Property(e => e.NumNights).HasColumnName("numNights");
            entity.Property(e => e.Observations)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("observations");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

            entity.HasOne<Cabin>()
                 .WithMany()
                 .HasForeignKey(d => d.CabinId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne<Person>()
                .WithMany()
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        });

        modelBuilder.Entity<Cabin>(entity =>
        {
            entity.ToTable("cabins");

            entity.Property(e => e.Id).HasColumnName("id" );
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");

            entity.Property(e => e.Image)
        .HasColumnType("VARCHAR(MAX)")
        .HasColumnName("image");


            entity.Property(e => e.MaxCapacity).HasColumnName("maxCapacity");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.RegularPrice).HasColumnName("regularPrice");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.CountryFlag)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("countryFlag");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("fullName");
            entity.Property(e => e.NationalId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("nationalID");
            entity.Property(e => e.Nationality)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("nationality");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BreakfastPrice).HasColumnName("breakfastPrice");
            entity.Property(e => e.MaxBookingLength).HasColumnName("maxBookingLength");
            entity.Property(e => e.MaxGuestsPerBooking).HasColumnName("maxGuestsPerBooking");
            entity.Property(e => e.MinBookingLength).HasColumnName("minBookingLength");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
