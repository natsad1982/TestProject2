
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/19/2019 16:52:48
-- Generated from EDMX file: D:\projects\Visual Studio\GIT-PROJECTS\ITC\Medical\MedicalCard\Models\TestModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Interactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Interactions];
GO
IF OBJECT_ID(N'[dbo].[Specialists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specialists];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IIN] nvarchar(12)  NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(150)  NULL,
    [Address] nvarchar(350)  NULL,
    [Phone] nvarchar(100)  NULL
);
GO

-- Creating table 'Interactions'
CREATE TABLE [dbo].[Interactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SpecialistId] int  NULL,
    [ClientId] int  NOT NULL,
    [Diagnose] nvarchar(500)  NULL,
    [Zhaloby] nvarchar(500)  NULL,
    [DateEntered] datetime  NULL,
    [Client1] nvarchar(250)  NULL
);
GO

-- Creating table 'Specialists'
CREATE TABLE [dbo].[Specialists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(150)  NULL,
    [Position] nvarchar(350)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Interactions'
ALTER TABLE [dbo].[Interactions]
ADD CONSTRAINT [PK_Interactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Specialists'
ALTER TABLE [dbo].[Specialists]
ADD CONSTRAINT [PK_Specialists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------