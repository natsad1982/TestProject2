CREATE TABLE [dbo].[Interactions] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [SpecialistId] INT            NULL,
    [ClientId]     INT            NOT NULL,
    [Diagnose]     NVARCHAR (500) NULL,
    [Zhaloby]      NVARCHAR (500) NULL,
    [DateEntered]  DATETIME       NULL, 
    CONSTRAINT [PK_Interactions] PRIMARY KEY NONCLUSTERED ([Id]),
	CONSTRAINT FK_Interactions FOREIGN KEY (ClientId)
	REFERENCES Clients (Id) ON DELETE CASCADE
);