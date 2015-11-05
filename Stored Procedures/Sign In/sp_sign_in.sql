USE [Banking System] 
GO

ALTER PROCEDURE sp_sign_in
--CREATE PROCEDURE sp_sign_in
@UserName nvarchar(15),
@Password nvarchar(15),
--@EmpNumber int
--@PwdAttempt int,
--@Lock bit
@ErrorMsg nvarchar(120)
--@nameOfUser nvarchar(30)

AS
	BEGIN
		SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRANSACTION

			SELECT userName,userPwd,lock,errorMsg,pwdAttempt,firstname,surname,empNumber 
			FROM [Users].[Users] ,[HumanResources].[Employees] 
			WHERE userName = @UserName AND emplNumber = (SELECT empNumber FROM [Users].[Users] WHERE userName = @UserName) AND pwdAttempt > 0

			if @ErrorMsg =(SELECT errorMsg FROM [Users].[Users] WHERE userName = @UserName AND userPwd = @Password)

			UPDATE [Users].[Users]  SET pwdAttempt=3 ,lock='True', errorMsg=@ErrorMsg 
			WHERE userName = @UserName AND userPwd = @Password
			
			IF  @UserName =(SELECT userName FROM [Users].[Users] WHERE userName = @UserName AND userPwd = @Password)  and @Password = (SELECT userPwd FROM [Users].[Users] WHERE userName = @UserName AND userPwd = @Password)

			UPDATE [Users].[Users]  SET pwdAttempt=3 ,lock='True', errorMsg=@ErrorMsg 
			WHERE userName = @UserName AND userPwd = @Password

			--UPDATE [Users].[Users]  SET pwdAttempt=3 ,lock='True'
			--WHERE userName = @UserName AND userPwd = @Password

			ELSE

			UPDATE [Users].[Users]  SET pwdAttempt=pwdAttempt-1 
			WHERE userName = @UserName

		COMMIT TRANSACTION;
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
			END
		END CATCH
END;
