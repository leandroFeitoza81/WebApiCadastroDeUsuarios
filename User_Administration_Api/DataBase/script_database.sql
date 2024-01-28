use CadastroUsuarios_Db

CREATE TABLE [Tb_User] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	NickName VARCHAR(50) NOT NULL,
	Password VARCHAR(500) NOT NULL,
	DateBirth DATE
);

INSERT INTO [dbo].[Tb_User]
           ([Name]
           ,[Email]
           ,[NickName]
		   ,[Password]
		   ,[DateBirth]
		   )
     VALUES
			('Mick Jagger', 'mick@email.com', 'mick', 'senha123', '1/06/1955' ),
			('Kurt Cobain', 'kurt@email.com', 'kurt', 'senha123', '1/04/1944' ),
			('Max Cavalera', 'max@email.com', 'max', 'senha123', '1/06/1955' ),
			('Janis Joplin', 'janis@email.com', 'janis', 'senha123', '1/10/1988' ),
			('Bob Dylan', 'bob@email.com', 'bob', 'senha123', '1/06/1975' )
GO


INSERT INTO [dbo].[Tb_User]
           ([Name]
           ,[Email]
           ,[NickName]
		   ,[Password]
		   ,[DateBirth]
		   )
     VALUES
			('Leandro Feitoza', 'leandro@email.com', 'leo', 'senhaSecret@', '11/08/1981' )
GO


select * from [Tb_User]

declare @name varchar(100); set @name = 'mick'

select * from [Tb_User] where Name like '%'+@name+'%'