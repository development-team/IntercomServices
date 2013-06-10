
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/10/2013 19:37:57
-- Generated from EDMX file: C:\projects\IntercomServices\IntercomServices\IntercomServices\Models\IntercomServices.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IntercomContext];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [ObjectID] int IDENTITY(1,1) NOT NULL,
    [CallerName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [BuildingID] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [StatusReason] nvarchar(max)  NOT NULL,
    [Status] int  NOT NULL,
    [Assignee] int  NOT NULL
);
GO

-- Creating table 'BaseDictionaries'
CREATE TABLE [dbo].[BaseDictionaries] (
    [ObjectID] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ParentEntry_BaseDictionary_ObjectID] int  NOT NULL
);
GO

-- Creating table 'BaseDictionaries_Street'
CREATE TABLE [dbo].[BaseDictionaries_Street] (
    [ObjectID] int  NOT NULL
);
GO

-- Creating table 'BaseDictionaries_TicketType'
CREATE TABLE [dbo].[BaseDictionaries_TicketType] (
    [ObjectID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ObjectID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([ObjectID] ASC);
GO

-- Creating primary key on [ObjectID] in table 'BaseDictionaries'
ALTER TABLE [dbo].[BaseDictionaries]
ADD CONSTRAINT [PK_BaseDictionaries]
    PRIMARY KEY CLUSTERED ([ObjectID] ASC);
GO

-- Creating primary key on [ObjectID] in table 'BaseDictionaries_Street'
ALTER TABLE [dbo].[BaseDictionaries_Street]
ADD CONSTRAINT [PK_BaseDictionaries_Street]
    PRIMARY KEY CLUSTERED ([ObjectID] ASC);
GO

-- Creating primary key on [ObjectID] in table 'BaseDictionaries_TicketType'
ALTER TABLE [dbo].[BaseDictionaries_TicketType]
ADD CONSTRAINT [PK_BaseDictionaries_TicketType]
    PRIMARY KEY CLUSTERED ([ObjectID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ParentEntry_BaseDictionary_ObjectID] in table 'BaseDictionaries'
ALTER TABLE [dbo].[BaseDictionaries]
ADD CONSTRAINT [FK_ParentEntry]
    FOREIGN KEY ([ParentEntry_BaseDictionary_ObjectID])
    REFERENCES [dbo].[BaseDictionaries]
        ([ObjectID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ParentEntry'
CREATE INDEX [IX_FK_ParentEntry]
ON [dbo].[BaseDictionaries]
    ([ParentEntry_BaseDictionary_ObjectID]);
GO

-- Creating foreign key on [ObjectID] in table 'BaseDictionaries_Street'
ALTER TABLE [dbo].[BaseDictionaries_Street]
ADD CONSTRAINT [FK_Street_inherits_BaseDictionary]
    FOREIGN KEY ([ObjectID])
    REFERENCES [dbo].[BaseDictionaries]
        ([ObjectID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ObjectID] in table 'BaseDictionaries_TicketType'
ALTER TABLE [dbo].[BaseDictionaries_TicketType]
ADD CONSTRAINT [FK_TicketType_inherits_BaseDictionary]
    FOREIGN KEY ([ObjectID])
    REFERENCES [dbo].[BaseDictionaries]
        ([ObjectID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------