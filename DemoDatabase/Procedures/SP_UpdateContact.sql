CREATE PROCEDURE [dbo].[SP_UpdateContact]
	@Id INT,
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384) = null,
	@Phone NVARCHAR(30) = null,
	@UserId int
AS
Begin
	Update Contact Set LastName = @LastName, 
					   FirstName = @FirstName, 
					   Email = @Email, 
					   Phone = @Phone
	Where Id = @Id and UserId = @UserId;
End
