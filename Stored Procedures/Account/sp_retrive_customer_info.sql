USE [Banking System] 
GO

--ALTER PROCEDURE sp_retrive_customer_info
CREATE PROCEDURE sp_retrive_customer_info
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

		SELECT firstName,lastName,surname,identityNumber,DOB,gender,cellNumber,email,address1,address2,picture,idCopy,Residence,ConsernForm
		FROM Customer.Customers, Customer.Contact, Customer.Images 
		WHERE identityNumber = @IdentityNumber AND CustIDConact = @CustomerID AND CustIDImages = @CustomerID 
		
		IF @CheckAcc  = @AccountNumber 

		 SELECT firstName,lastName,surname,identityNumber,DOB,gender,cellNumber,email,address1,address2,picture,idCopy,Residence,ConsernForm
		 FROM Customer.Customers, Customer.Contact, Customer.Images 
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