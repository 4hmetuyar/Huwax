
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/08/2015 16:25:51
-- Generated from EDMX file: C:\Users\Profesor\Source\Repos\Huwax\Huwax.Dal\HuwaxModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Huwax];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cari]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cari];
GO
IF OBJECT_ID(N'[dbo].[CariOperation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CariOperation];
GO
IF OBJECT_ID(N'[dbo].[CarWash]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarWash];
GO
IF OBJECT_ID(N'[dbo].[DayOff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DayOff];
GO
IF OBJECT_ID(N'[dbo].[Personnel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personnel];
GO
IF OBJECT_ID(N'[dbo].[Salary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salary];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Vehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicle];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cari'
CREATE TABLE [dbo].[Cari] (
    [CariId] int IDENTITY(1,1) NOT NULL,
    [TCNo] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Fax] nvarchar(50)  NULL,
    [TaxNumber] nvarchar(50)  NULL,
    [TaxOffice] nvarchar(50)  NULL,
    [Company] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [Province] nvarchar(50)  NULL,
    [District] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'CariOperation'
CREATE TABLE [dbo].[CariOperation] (
    [CariOperationId] int IDENTITY(1,1) NOT NULL,
    [CariId] int  NULL,
    [Total] int  NULL,
    [Description] nvarchar(max)  NULL,
    [Status] int  NULL,
    [Date] datetime  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'CarWash'
CREATE TABLE [dbo].[CarWash] (
    [CarWashId] int IDENTITY(1,1) NOT NULL,
    [VehicleId] int  NULL,
    [Date] datetime  NULL,
    [Total] int  NULL,
    [Description] nvarchar(max)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'DayOff'
CREATE TABLE [dbo].[DayOff] (
    [DayOffId] int IDENTITY(1,1) NOT NULL,
    [PersonnelId] int  NULL,
    [Date] datetime  NULL,
    [UserId] int  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [CratedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Personnel'
CREATE TABLE [dbo].[Personnel] (
    [PersonnelId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Salary'
CREATE TABLE [dbo].[Salary] (
    [SalaryId] int IDENTITY(1,1) NOT NULL,
    [PersonnelId] int  NULL,
    [Total] int  NULL,
    [Description] nvarchar(max)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [Name] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Avatar] varbinary(max)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Vehicle'
CREATE TABLE [dbo].[Vehicle] (
    [VehicleId] int IDENTITY(1,1) NOT NULL,
    [VehicleName] nvarchar(50)  NULL,
    [VehiclePlate] nvarchar(50)  NULL,
    [Model] nvarchar(50)  NULL,
    [Year] nvarchar(50)  NULL,
    [Gear] nvarchar(50)  NULL,
    [Fuel] nvarchar(50)  NULL,
    [Km] nvarchar(50)  NULL,
    [Color] nvarchar(50)  NULL,
    [Description] nvarchar(max)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [IsDeleted] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CariId] in table 'Cari'
ALTER TABLE [dbo].[Cari]
ADD CONSTRAINT [PK_Cari]
    PRIMARY KEY CLUSTERED ([CariId] ASC);
GO

-- Creating primary key on [CariOperationId] in table 'CariOperation'
ALTER TABLE [dbo].[CariOperation]
ADD CONSTRAINT [PK_CariOperation]
    PRIMARY KEY CLUSTERED ([CariOperationId] ASC);
GO

-- Creating primary key on [CarWashId] in table 'CarWash'
ALTER TABLE [dbo].[CarWash]
ADD CONSTRAINT [PK_CarWash]
    PRIMARY KEY CLUSTERED ([CarWashId] ASC);
GO

-- Creating primary key on [DayOffId] in table 'DayOff'
ALTER TABLE [dbo].[DayOff]
ADD CONSTRAINT [PK_DayOff]
    PRIMARY KEY CLUSTERED ([DayOffId] ASC);
GO

-- Creating primary key on [PersonnelId] in table 'Personnel'
ALTER TABLE [dbo].[Personnel]
ADD CONSTRAINT [PK_Personnel]
    PRIMARY KEY CLUSTERED ([PersonnelId] ASC);
GO

-- Creating primary key on [SalaryId] in table 'Salary'
ALTER TABLE [dbo].[Salary]
ADD CONSTRAINT [PK_Salary]
    PRIMARY KEY CLUSTERED ([SalaryId] ASC);
GO

-- Creating primary key on [UserId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [VehicleId] in table 'Vehicle'
ALTER TABLE [dbo].[Vehicle]
ADD CONSTRAINT [PK_Vehicle]
    PRIMARY KEY CLUSTERED ([VehicleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------