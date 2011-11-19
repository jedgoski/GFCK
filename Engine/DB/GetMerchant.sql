USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetMerchant]    Script Date: 11/19/2011 15:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetMerchant]
@MerchantID BigInt	
AS

	Select m.ID, 
		m.UserID,
		asp.UserName,
		m.FirstName, 
		m.LastName,
		m.MerchantName,
		m.Description, 
		m.Email, 
		m.PhoneNumber, 
		m.Address, 
		m.Address2,
		m.City,
		m.State,
		m.Zip,
		m.CreatedDate, 
		m.UpdatedDate, 
		m.Deleted
	From dbo.Merchant m left join dbo.aspnet_Users asp on m.UserID = asp.UserId
	Where ID = @MerchantID
