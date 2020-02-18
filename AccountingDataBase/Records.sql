CREATE TABLE [dbo].[Records]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserId] INT NOT NULL,
	[Tittle] NVARCHAR (50) NULL,
    [FirstName] NVARCHAR (50) NULL,
	[DateOfCreating] DATETIME NULL
)

