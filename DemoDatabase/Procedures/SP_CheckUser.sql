CREATE PROCEDURE [dbo].[SP_CheckUser]
	@Email NVARCHAR(50),
	@Passwd NVARCHAR(20)
AS
Begin
	Select Id, LastName, FirstName, @Email Email
	From [User]
	Where Email = @Email and Passwd = HASHBYTES('SHA2_512', dbo.GetSalt() + @Passwd);
End