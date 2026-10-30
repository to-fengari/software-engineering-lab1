-- Task 2. SQL Server Database Setup
-- Run against (localdb)\MSSQLLocalDB to create BookstoreDB with a
-- one-to-many relationship: an Author has many Books.

IF DB_ID('BookstoreDB') IS NULL
    CREATE DATABASE BookstoreDB;
GO

USE BookstoreDB;
GO

IF OBJECT_ID('dbo.Books', 'U') IS NOT NULL DROP TABLE dbo.Books;
IF OBJECT_ID('dbo.Authors', 'U') IS NOT NULL DROP TABLE dbo.Authors;
GO

CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    Name     NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Books (
    BookID   INT IDENTITY(1,1) PRIMARY KEY,
    Title    NVARCHAR(200) NOT NULL,
    AuthorID INT NOT NULL,
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorID)
        REFERENCES Authors(AuthorID)
);
GO
