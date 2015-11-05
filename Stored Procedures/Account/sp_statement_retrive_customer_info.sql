USE [Banking System] 
GO

--ALTER PROCEDURE sp_statement_retrive_customer_info
CREATE PROCEDURE sp_statement_retrive_customer_info
@IdentityNumber nvarchar(13),
@AccountNumber int,
@CustomerID int,
@CustIDAcc int,
@CheckID nvarchar(13),
@CheckAcc int

AS 
	BEGIN
		SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION


		SET @CustomerID = (SELECT CustomerID FROM Customer.Customers WHERE identityNumber = @IdentityNumber)
		SET @CustIDAcc = (SELECT CustIDAcc FROM Customer.Account WHERE accNumber = @AccountNumber)
		SET @CheckID = (SELECT identityNumber FROM Customer.Customers WHERE identityNumber = @IdentityNumber)
		SET @CheckAcc = (SELECT accNumber FROM Customer.Account WHERE accNumber = @AccountNumber)

		if @CheckID = @IdentityNumber 

		SELECT accNumber,accType,firstName,lastName,surname,title,cellNumber,[address1],picture
		FROM Customer.Customers, Customer.Contact, Customer.Images, Customer.Account
		WHERE identityNumber = @IdentityNumber AND CustIDConact = @CustomerID AND CustIDImages = @CustomerID 
		
		IF @CheckAcc  = @AccountNumber 

		 SELECT accNumber,accType,firstName,lastName,surname,title,cellNumber,[address1],picture
		 FROM Customer.Customers, Customer.Contact, Customer.Images, Customer.Account
		 WHERE CustomerID = (SELECT CustIDAcc FROM Customer.Account WHERE accNumber = @AccountNumber) AND CustIDConact = @CustIDAcc AND CustIDImages = @CustIDAcc 

		 
		COMMIT TRANSACTION
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION
			END
		END CATCH
END;