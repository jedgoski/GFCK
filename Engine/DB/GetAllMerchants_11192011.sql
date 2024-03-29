USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetAllMerchants]    Script Date: 11/19/2011 15:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllMerchants]
@Deleted bit = null

AS

	Select ID, 
		UserID,
		FirstName, 
		LastName,
		MerchantName,
		Description, 
		Email, 
		PhoneNumber, 
		Address, 
		Address2,
		City,
		State,
		Zip,
		CreatedDate, 
		UpdatedDate, 
		Deleted
	From dbo.Merchant
	Where ((@Deleted is null) or (Deleted = @Deleted))
	Order By MerchantName
