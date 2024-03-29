USE [GFCK]
GO
/****** Object:  StoredProcedure [dbo].[GetMerchantByUserID]    Script Date: 11/19/2011 15:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetMerchantByUserID]
@UserID uniqueidentifier	
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
	From dbo.UsersInMerchant uim
		left join dbo.Merchant m on uim.MerchantID = m.ID
		left join dbo.aspnet_Users asp on m.UserID = asp.UserId
	Where uim.UserID = @UserID
