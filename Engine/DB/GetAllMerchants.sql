USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetAllMerchants]    Script Date: 11/08/2011 20:34:36 ******/
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
		CreatedDate, 
		UpdatedDate, 
		Deleted
	From dbo.Merchant
	Where ((@Deleted is null) or (Deleted = @Deleted))
	Order By MerchantName
