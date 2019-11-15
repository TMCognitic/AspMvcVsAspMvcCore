CREATE PROCEDURE [dbo].[SP_GetContacts]
	@UserId int
AS
	Select Id, LastName, FirstName, Email, Phone
	From Contact
	Where UserId = @UserId;
RETURN 0
