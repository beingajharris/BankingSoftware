USE [Banking System] 
GO

--ALTER PROCEDURE sp_get_accounts
CREATE PROCEDURE sp_get_accounts
@IdentityNumber nvarchar(13),
@AccountNumber int,
@CheckID nvarchar(13),
@CheckAcc int
AS
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

		SET @CheckID = (SELECT identityNumber FROM Customer.Customers WHERE identityNumber = @IdentityNumber)
		SET @CheckAcc = (SELECT accNumber FROM Customer.Account WHERE accNumber = @AccountNumber)

		if @CheckID = @IdentityNumber

		BEGIN

		SELECT accNumber AS Account_Number, accType AS Account_Type, balance AS Balance, accState AS Account_State, dateOpened AS Date_opened FROM [Customer].[Account] WHERE CustIDAcc = (SELECT CustomerID FROM [Customer].[Customers] WHERE identityNumber=@IdentityNumber)
		
		END

		IF @CheckAcc  = @AccountNumber 

		BEGIN

		SELECT accNumber AS Account_Number, accType AS Account_Type, balance AS Balance, accState AS Account_State, dateOpened AS Date_opened FROM [Customer].[Account] WHERE accNumber = @AccountNumber
		
		END

COMMIT TRANSACTION
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION
			END
		END CATCH
END;