CREATE PROCEDURE [dbo].[SP_AddContact]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384) = null,
	@Phone NVARCHAR(30) = null,
	@UserId int
AS
Begin
	Insert into Contact (LastName, FirstName, Email, Phone, UserId)
	Output Inserted.Id
	Values (@LastName, @FirstName, @Email, @Phone, @UserId);
End
