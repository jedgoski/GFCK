USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[AddMerchant]    Script Date: 11/19/2011 15:44:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddMerchant]
@UserID UniqueIdentifier,
@FirstName NVarChar (50),
@LastName NVarChar (50),
@MerchantName NVarChar (50),
@Description NVarChar (1500),	
@Email NVarChar (100),	
@PhoneNumber NVarChar (25),	
@Address NVarChar (100),		
@Address2 NVarChar (50),		
@City NVarChar (50),		
@State NVarChar (50),		
@Zip NVarChar (10),		
@Deleted Bit			
AS

Insert Into dbo.Merchant (UserID, FirstName, LastName, MerchantName, [Description], Email, PhoneNumber, [Address], Address2, City, [State], Zip, CreatedDate, Deleted)
Values(@UserID, @FirstName, @LastName, @MerchantName, @Description, @Email, @PhoneNumber, @Address, @Address2, @City, @State, @Zip, GETDATE(), @Deleted) 
		
Insert Into dbo.UsersInMerchant(UserID, MerchantID)
Values (@UserID, SCOPE_IDENTITY())
