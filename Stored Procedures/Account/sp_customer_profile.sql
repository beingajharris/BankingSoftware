USE [Banking System] 
GO

--ALTER PROCEDURE sp_customer_profile
CREATE PROCEDURE sp_customer_profile
@AccountNumber int,
@IdentityNumber nvarchar(13),
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

		--SELECT firstName,lastName,surname,identityNumber,DOB,gender,cellNumber,email,address1,address2,accNumber,accType,accState,dateOpened,expires,picture
		--FROM Customer.Customers , Customer.Contact, Customer.Account, Customer.Images
		--WHERE identityNumber = @IdentityNumber AND CustIDConact = @CustomerID AND CustIDAcc = @CustomerID 



		if @CheckID = @IdentityNumber 

		SELECT firstName,lastName,surname,identityNumber,DOB,gender,cellNumber,email,address1,address2,picture,accNumber,accType,accState,dateOpened,expires
		FROM Customer.Customers, Customer.Account, Customer.Contact, Customer.Images 
		WHERE identityNumber = @IdentityNumber AND CustIDAcc = @CustomerID AND CustIDConact = @CustomerID AND CustIDImages = @CustomerID 
		
		IF @CheckAcc  = @AccountNumber 

		 SELECT firstName,lastName,surname,identityNumber,DOB,gender,cellNumber,email,address1,address2,picture,accNumber,accType,accState,dateOpened,expires
		 FROM Customer.Customers, Customer.Account, Customer.Contact, Customer.Images 
		 WHERE CustomerID = (SELECT CustIDAcc FROM Customer.Account WHERE accNumber = @AccountNumber) AND CustIDAcc = @CustIDAcc AND CustIDConact = @CustIDAcc AND CustIDImages = @CustIDAcc 

COMMIT TRANSACTION;
	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
			END
		END CATCH
END;
