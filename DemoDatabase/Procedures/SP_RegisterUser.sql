CREATE PROCEDURE [dbo].[SP_RegisterUser]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(50),
	@Passwd NVARCHAR(20)
AS
Begin
	Insert into [User] (LastName, FirstName, Email, Passwd)
	Output Inserted.Id
	values (@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.GetSalt() + @Passwd));
End
