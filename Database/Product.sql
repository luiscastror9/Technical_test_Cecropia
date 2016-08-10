CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Brand] NCHAR(10) NOT NULL, 
    [Size] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [Price] MONEY NOT NULL DEFAULT 0, 
    [Quantity_in_stock] INT NOT NULL DEFAULT 0, 
    [Created_date] DATETIME NOT NULL, 
    [Updated_date] DATETIME NOT NULL
)
