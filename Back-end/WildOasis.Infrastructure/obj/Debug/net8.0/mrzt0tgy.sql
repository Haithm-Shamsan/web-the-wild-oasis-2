IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [cabins] (
    [id] int NOT NULL IDENTITY,
    [name] nchar(100) NOT NULL,
    [maxCapacity] tinyint NOT NULL,
    [regularPrice] float NOT NULL,
    [discount] smallint NOT NULL,
    [description] varchar(300) NOT NULL,
    [image] VARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_cabins] PRIMARY KEY ([id])
);
GO

CREATE TABLE [People] (
    [PersonId] int NOT NULL IDENTITY,
    [fullName] nchar(50) NOT NULL,
    [email] nchar(100) NOT NULL,
    [nationalID] nchar(20) NOT NULL,
    [nationality] nchar(30) NOT NULL,
    [countryFlag] nchar(30) NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([PersonId])
);
GO

CREATE TABLE [Settings] (
    [id] int NOT NULL,
    [minBookingLength] smallint NOT NULL,
    [maxBookingLength] smallint NOT NULL,
    [maxGuestsPerBooking] smallint NOT NULL,
    [breakfastPrice] float NOT NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Bookings] (
    [BookingId] int NOT NULL IDENTITY,
    [startDate] datetime NOT NULL,
    [endDate] datetime NOT NULL,
    [numNights] smallint NOT NULL,
    [numGuests] smallint NOT NULL,
    [cabinPrice] float NOT NULL,
    [extrasPrice] float NOT NULL,
    [totalPrice] float NOT NULL,
    [status] nchar(15) NOT NULL,
    [hasBreakfast] bit NOT NULL,
    [isPaid] bit NOT NULL,
    [observations] nchar(100) NOT NULL,
    [cabinId] int NOT NULL,
    [personId] int NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([BookingId]),
    CONSTRAINT [FK_Bookings_People_personId] FOREIGN KEY ([personId]) REFERENCES [People] ([PersonId]),
    CONSTRAINT [FK_Bookings_cabins_cabinId] FOREIGN KEY ([cabinId]) REFERENCES [cabins] ([id])
);
GO

CREATE INDEX [IX_Bookings_cabinId] ON [Bookings] ([cabinId]);
GO

CREATE INDEX [IX_Bookings_personId] ON [Bookings] ([personId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240914051516_UpdateImageField', N'8.0.8');
GO

COMMIT;
GO

