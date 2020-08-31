use ejercicio015;

CREATE TABLE [dbo].[Salas] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]       NVARCHAR (MAX) NOT NULL,
    [CapacidadMax] INT            NOT NULL,
    [Activa]       BIT            NOT NULL,
    CONSTRAINT [PK_Salas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Peliculas] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Titulo]          NVARCHAR (MAX) NOT NULL,
    [Año]             INT            NOT NULL,
    [Director]        NVARCHAR (MAX) NOT NULL,
    [Duracion]        INT            NOT NULL,
    [ElencoPrincipal] NVARCHAR (MAX) NOT NULL,
    [Activa]          BIT            NOT NULL,
    CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Sesiones] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [SalaId]            INT            NOT NULL,
    [PeliculaId]        INT            NOT NULL,
    [Hora]              DATE           NOT NULL,
    [Activa]            BIT            NOT NULL,
    [EntradasRestantes] INT            NULL,
    CONSTRAINT [PK_Sesiones] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sesiones_Peliculas_PeliculaId] FOREIGN KEY ([PeliculaId]) REFERENCES [dbo].[Peliculas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sesiones_Salas_SalaId] FOREIGN KEY ([SalaId]) REFERENCES [dbo].[Salas] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Entradas] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [Precio]          INT NOT NULL,
    [EntradasTotales] INT NOT NULL,
    [Descuento]       INT  NULL,
    [SesionId]        INT NOT NULL,
    [GananciaTotal]   INT  NULL,
    CONSTRAINT [PK_Entradas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Entradas_Sesiones_SesionId] FOREIGN KEY ([SesionId]) REFERENCES [dbo].[Sesiones] ([Id]) ON DELETE CASCADE
);
