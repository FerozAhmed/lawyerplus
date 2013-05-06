
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/12/2013 00:01:59
-- Generated from EDMX file: h:\TR - Copy\GetLow\datatree.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dataModelStoreContainer].[data]', 'U') IS NOT NULL
    DROP TABLE [dataModelStoreContainer].[data];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'data'
CREATE TABLE [dbo].[data] (
    [id] integer  NOT NULL,
    [parent_id] integer  NULL,
    [name] nvarchar(2147483647)  NOT NULL,
    [data_text] nvarchar(2147483647)  NULL,
    [data_rtf] nvarchar(2147483647)  NULL,
    [position] integer  NOT NULL,
    [site_id] nvarchar(2147483647)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'data'
ALTER TABLE [dbo].[data]
ADD CONSTRAINT [PK_data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------