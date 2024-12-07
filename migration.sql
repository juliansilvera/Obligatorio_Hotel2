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

CREATE TABLE [Habitaciones] (
    [Numero] int NOT NULL IDENTITY,
    [Tipo] nvarchar(max) NOT NULL,
    [Capacidad] int NOT NULL,
    [PrecioDiario] decimal(18,2) NOT NULL,
    [EstaDisponible] bit NOT NULL,
    CONSTRAINT [PK_Habitaciones] PRIMARY KEY ([Numero])
);
GO

CREATE TABLE [Huespedes] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [Email] nvarchar(450) NOT NULL,
    [Contraseña] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Huespedes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Reservas] (
    [NumeroReserva] int NOT NULL IDENTITY,
    [NumeroHabitacion] int NOT NULL,
    [HuespedId] int NOT NULL,
    [FechaInicio] datetime2 NOT NULL,
    [FechaFin] datetime2 NOT NULL,
    CONSTRAINT [PK_Reservas] PRIMARY KEY ([NumeroReserva]),
    CONSTRAINT [FK_Reservas_Habitaciones_NumeroHabitacion] FOREIGN KEY ([NumeroHabitacion]) REFERENCES [Habitaciones] ([Numero]) ON DELETE SET NULL,
    CONSTRAINT [FK_Reservas_Huespedes_HuespedId] FOREIGN KEY ([HuespedId]) REFERENCES [Huespedes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Pagos] (
    [Id] int NOT NULL IDENTITY,
    [NumeroReserva] int NOT NULL,
    [Monto] decimal(18,2) NOT NULL,
    [FechaPago] datetime2 NOT NULL,
    CONSTRAINT [PK_Pagos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pagos_Reservas_NumeroReserva] FOREIGN KEY ([NumeroReserva]) REFERENCES [Reservas] ([NumeroReserva]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Huespedes_Email] ON [Huespedes] ([Email]);
GO

CREATE INDEX [IX_Pagos_NumeroReserva] ON [Pagos] ([NumeroReserva]);
GO

CREATE INDEX [IX_Reservas_HuespedId] ON [Reservas] ([HuespedId]);
GO

CREATE INDEX [IX_Reservas_NumeroHabitacion] ON [Reservas] ([NumeroHabitacion]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241205031623_Inicio', N'6.0.0');
GO

COMMIT;
GO

