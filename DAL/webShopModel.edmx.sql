
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/10/2015 19:54:38
-- Generated from EDMX file: D:\z_workspace\WebShop\DAL\webShopModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [webShopDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_ClientAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_CityAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_CityAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ClientOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderLines] DROP CONSTRAINT [FK_OrderOrderLine];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[OrderLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderLines];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(100)  NULL,
    [LastName] nvarchar(100)  NULL,
    [Title] nvarchar(10)  NULL,
    [Email] nvarchar(200)  NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(250)  NULL,
    [HouseNumber] nvarchar(10)  NULL,
    [ZipCode] int  NULL,
    [Client_Id] int  NOT NULL,
    [City_Id] int  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClientId] int  NOT NULL
);
GO

-- Creating table 'OrderLines'
CREATE TABLE [dbo].[OrderLines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL
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

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [PK_OrderLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Client_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_ClientAddress]
    FOREIGN KEY ([Client_Id])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAddress'
CREATE INDEX [IX_FK_ClientAddress]
ON [dbo].[Addresses]
    ([Client_Id]);
GO

-- Creating foreign key on [City_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_CityAddress]
    FOREIGN KEY ([City_Id])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityAddress'
CREATE INDEX [IX_FK_CityAddress]
ON [dbo].[Addresses]
    ([City_Id]);
GO

-- Creating foreign key on [ClientId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ClientOrder]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientOrder'
CREATE INDEX [IX_FK_ClientOrder]
ON [dbo].[Orders]
    ([ClientId]);
GO

-- Creating foreign key on [OrderId] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [FK_OrderOrderLine]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderLine'
CREATE INDEX [IX_FK_OrderOrderLine]
ON [dbo].[OrderLines]
    ([OrderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------