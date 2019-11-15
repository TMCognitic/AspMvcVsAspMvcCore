CREATE PROCEDURE [dbo].[SP_DeleteContact]
	@UserId int,
	@Id int
AS
Begin
	Delete From Contact
	Where Id = @Id and UserId = @UserId;
End
