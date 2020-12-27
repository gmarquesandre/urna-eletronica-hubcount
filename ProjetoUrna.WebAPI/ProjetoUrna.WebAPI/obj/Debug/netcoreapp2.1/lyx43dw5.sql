IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Candidatos] (
    [IdCandidato] int NOT NULL IDENTITY,
    [NomeCandidato] nvarchar(max) NULL,
    [NomeVice] nvarchar(max) NULL,
    [Legenda] nvarchar(max) NULL,
    [TipoCandidato] int NOT NULL,
    CONSTRAINT [PK_Candidatos] PRIMARY KEY ([IdCandidato])
);

GO

CREATE TABLE [Votos] (
    [IdCandidato] int NOT NULL,
    [DataVoto] datetime2 NOT NULL,
    [CodigoVoto] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Votos] PRIMARY KEY ([CodigoVoto])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201201031143_initial', N'2.1.14-servicing-32113');

GO

