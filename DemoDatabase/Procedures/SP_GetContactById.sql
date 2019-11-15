CREATE PROCEDURE [dbo].[SP_GetContactById]
	@UserId int,
	@Id int
AS
	Select @Id, LastName, FirstName, Email, Phone
	From Contact
	Where Id = @Id and UserId = @UserId;
RETURN 0
