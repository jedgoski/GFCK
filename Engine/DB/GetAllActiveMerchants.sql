USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetAllActiveMerchants]    Script Date: 11/19/2011 15:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetAllActiveMerchants]

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
	Where Deleted = 0
	Order By MerchantName
